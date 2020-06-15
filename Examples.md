Here are the usecase examples for all of the shaders
====================================================

Contents
--------

[Gaussian Blur](https://github.com/HalflingHelper/Love2d-shaders/blob/master/Examples.md#gaussian-blur)

[Smoke](https://github.com/HalflingHelper/Love2d-shaders/blob/master/Examples.md#smoke)

[Water](https://github.com/HalflingHelper/Love2d-shaders/blob/master/Examples.md#water)


Gaussian Blur
 -------------
 ```
 function love.load()
   currentCanvas = love.graphics.newCanvas()
   otherCanvas = love.graphics.newCanvas()
   image = love.graphics.newImage('z.png')
    
   gaussian_blur = love.graphics.newShader('blur.fs')

   gaussian_blur:send("image_size", {love.graphics.getPixelDimensions()})
end   
 
function love.draw()
   --Draw everything you want blurred to this canvas
   currentCanvas:renderTo(function()
        love.graphics.draw(image, 0, 0)
        love.graphics.rectangle('fill', 100, 100, 100, 100)
   end)

   love.graphics.setShader(gaussian_blur)

   --Render to otherCanvas blurred vertically
   otherCanvas:renderTo(function()
     gaussian_blur:send("horizontal", false)
     love.graphics.draw(currentCanvas)
   end)
   --Render to screen blurred horizontally
   gaussian_blur:send("horizontal", true)
   love.graphics.draw(otherCanvas)

   love.graphics.setShader()
end
```


Smoke
-----

```
function love.load()
  	mouseParticles = {}
  
    currentCanvas = love.graphics.newCanvas()
    otherCanvas = love.graphics.newCanvas()
       
    smoke_shader = love.graphics.newShader('smoke.fs')
       
    smoke_shader:send("screen", {love.graphics.getPixelDimensions()})
 end
    
 function love.update(dt)
 
    if love.mouse.isDown(1) then
        local mouseX, mouseY = love.mouse.getPosition()
        table.insert(mouseParticles, {x = mouseX, y = mouseY})
    end
 end
 
 function love.draw()
    currentCanvas:renderTo(function()
        for i, part in ipairs(mouseParticles) do
            love.graphics.circle('fill', part.x, part.y, 5)
        end
    end)
     
    mouseParticles = {}
     
    otherCanvas:renderTo(function()
        love.graphics.setShader(smoke_shader)
        love.graphics.draw(currentCanvas)
    end)
     
    currentCanvas:renderTo(function()
        love.graphics.clear()
        love.graphics.draw(otherCanvas)
        love.graphics.setShader()
    end)
    love.graphics.draw(currentCanvas)
     
    otherCanvas:renderTo(function() love.graphics.clear() end) 
 end
 ```
 
 
Water
-----
```
function love.load()
   currentCanvas = love.graphics.newCanvas()
   pastCanvas = love.graphics.newCanvas()
   displayCanvas = love.graphics.newCanvas()

   water_shader = love.graphics.newShader("water.fs")

   water_shader:send("screen", {love.graphics.getPixelDimensions()})

   --Background texture can also be a canvas
   image = love.graphics.newImage('z.png')
   water_shader:send("background_texture", image)
end   
 
function love.draw()
   --Potentially hold sources in a table to have multiple
   water_shader:send("source", {love.mouse.getPosition()})

   water_shader:send("past_texture", pastCanvas)
   water_shader:send("current_texture", currentCanvas)

   displayCanvas:renderTo(function()
      love.graphics.setShader(water_shader)
         love.graphics.draw(currentCanvas)
      love.graphics.setShader()
   end)
   
   pastCanvas:renderTo(function()
      love.graphics.draw(currentCanvas)
   end)
   
   currentCanvas:renderTo(function()
      love.graphics.draw(displayCanvas)
   end)

   love.graphics.draw(displayCanvas)
   
end
```
