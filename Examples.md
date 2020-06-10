Here are the usecase examples for all of the shaders
====================================================

Contents
--------

Smoke


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
