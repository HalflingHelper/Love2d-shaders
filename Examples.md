Here are the usecase examples for all of the shaders
====================================================

Contents
--------

Smoke

Inline <iframe
  src="https://carbon.now.sh/embed?bg=rgba(171%2C%20184%2C%20195%2C%201)&t=lucario&wt=none&l=auto&ds=true&dsyoff=20px&dsblur=68px&wc=true&wa=true&pv=56px&ph=56px&ln=false&fl=1&fm=Hack&fs=14px&lh=133%25&si=false&es=2x&wm=false&code=function%2520love.load()%250A%2520%2520%2509mouseParticles%2520%253D%2520%257B%257D%250A%2520%2520%250A%2520%2520%2520%2520currentCanvas%2520%253D%2520love.graphics.newCanvas()%250A%2520%2520%2520%2520otherCanvas%2520%253D%2520love.graphics.newCanvas()%250A%2520%2520%2520%2520%2520%2520%2520%250A%2520%2520%2520%2520smoke_shader%2520%253D%2520love.graphics.newShader(%27smoke.fs%27)%250A%2520%2520%2520%2520%2520%2520%2520%250A%2520%2520%2520%2520smoke_shader%253Asend(%2522screen%2522%252C%2520%257Blove.graphics.getPixelDimensions()%257D)%250A%2520end%250A%2520%2520%2520%2520%250A%2520function%2520love.update(dt)%250A%2520%250A%2520%2520%2520%2520if%2520love.mouse.isDown(1)%2520then%250A%2520%2520%2520%2520%2520%2520%2520%2520local%2520mouseX%252C%2520mouseY%2520%253D%2520love.mouse.getPosition()%250A%2520%2520%2520%2520%2520%2520%2520%2520table.insert(mouseParticles%252C%2520%257Bx%2520%253D%2520mouseX%252C%2520y%2520%253D%2520mouseY%257D)%250A%2520%2520%2520%2520end%250A%2520end%250A%2520%250A%2520function%2520love.draw()%250A%2520%2520%2520%2520currentCanvas%253ArenderTo(function()%250A%2520%2520%2520%2520%2520%2520%2520%2520for%2520i%252C%2520part%2520in%2520ipairs(mouseParticles)%2520do%250A%2520%2520%2520%2520%2520%2520%2520%2520%2520%2520%2520%2520love.graphics.circle(%27fill%27%252C%2520part.x%252C%2520part.y%252C%25205)%250A%2520%2520%2520%2520%2520%2520%2520%2520end%250A%2520%2520%2520%2520end)%250A%2520%2520%2520%2520%2520%250A%2520%2520%2520%2520mouseParticles%2520%253D%2520%257B%257D%250A%2520%2520%2520%2520%2520%250A%2520%2520%2520%2520otherCanvas%253ArenderTo(function()%250A%2520%2520%2520%2520%2520%2520%2520%2520love.graphics.setShader(smoke_shader)%250A%2520%2520%2520%2520%2520%2520%2520%2520love.graphics.draw(currentCanvas)%250A%2520%2520%2520%2520end)%250A%2520%2520%2520%2520%2520%250A%2520%2520%2520%2520currentCanvas%253ArenderTo(function()%250A%2520%2520%2520%2520%2520%2520%2520%2520love.graphics.clear()%250A%2520%2520%2520%2520%2520%2520%2520%2520love.graphics.draw(otherCanvas)%250A%2520%2520%2520%2520%2520%2520%2520%2520love.graphics.setShader()%250A%2520%2520%2520%2520end)%250A%2520%2520%2520%2520love.graphics.draw(currentCanvas)%250A%2520%2520%2520%2520%2520%250A%2520%2520%2520%2520otherCanvas%253ArenderTo(function()%2520love.graphics.clear()%2520end)%2520%250A%2520end"
  style="transform:scale(0.7); width:1024px; height:473px; border:0; overflow:hidden;"
  sandbox="allow-scripts allow-same-origin">
</iframe>