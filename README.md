# Love2d-shaders

This is a collection of the shaders I have modified to work with Love2d/created. Complete props to original creators. Feel free to use any of these in your projects without attribution.

# Credits

http://blogs.love2d.org/content/beginners-guide-shaders : This is a really good article that introduced me to shaders in Love2d.
https://love2d.org/ : Here you can find downloads for the latest version of Love2d, as well as links to the wiki and forums.

# A Few Special Notes
All of the shaders have example use cases. If they are self propogating, such as the smoke shader, they may require multiple canvases to work properly. All 
[examples](https://github.com/HalflingHelper/Love2d-shaders/blob/master/Examples.md) 
are relevant as of Love2d 11.3.

# Shaders

[blur.fs](https://github.com/HalflingHelper/Love2d-shaders/blob/master/blur.fs)

This is a shader based off of gaussian blur using an array of 10 values to approximate the curve.
I modified this shader from the gaussian blur section of [this article](https://learnopengl.com/Advanced-Lighting/Bloom) about bloom.

[smoke.fs](https://github.com/HalflingHelper/Love2d-shaders/blob/master/smoke.fs)

Turns pixels into a smoky effect.
I modified this shader from the download at [this link](https://love2d.org/forums/viewtopic.php?f=4&t=3733&p=167865#p167865) to work with Love 11.3.

[water.fs](https://github.com/HalflingHelper/Love2d-shaders/blob/master/water.fs)

Creates a water effect overtop of a background.
[This article](https://www.gamedev.net/articles/programming/graphics/the-water-effect-explained-r915/) was the source of inspiration for how the shader would work.
