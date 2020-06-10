# Love2d-shaders

This is a collection of the shaders I have modified to work with Love2d/created. Complete props to original creators. Feel free to use any of these in your projects without attribution.

# Credits

http://blogs.love2d.org/content/beginners-guide-shaders : This is a really good article that introduced me to shaders in Love2d.
https://love2d.org/ : Here you can find downloads for the latest version of Love2d, as well as links to the wiki and forums.

# A Few Special Notes
All of the shaders have example use cases. If they are self propogating, such as the smoke shader, they may require multiple canvases to work properly. All examples are relevant as of Love2d 11.3.

# Shaders

Smoke.fs
Turns pixels into a smoky effect.

```
function love.load()
   currentCanvas = love.graphics.newCanvas()
   otherCanvas = love.graphics.newCanvas()
      
   smoke_shader = love.graphics.newShader('smoke.fs')
      
   smoke:send("screen", {love.graphics.getPixelDimensions()})
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
    
   love.graphics.setShader(smoke)
    
   otherCanvas:renderTo(function()
     love.graphics.draw(currentCanvas)
   end)
    
   currentCanvas:renderTo(function()
     love.graphics.clear()
	    
	   love.graphics.draw(otherCanvas)
     love.graphics.clear() 
   end)
        
   love.graphics.draw(currentCanvas)
    
   otherCanvas:renderTo(function() love.graphics.clear() end) 
end
```
