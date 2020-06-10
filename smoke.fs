extern vec2 screen;

vec4 effect(vec4 color, Image texture, vec2 texture_coords, vec2 pixel_coords){

	vec4 pixel = Texel(texture, texture_coords );//This is the current pixel 
	vec2 tex_offset = 1.0 / screen; //Texel size

	vec4 Lpixel = Texel(texture, vec2(texture_coords.x - tex_offset.x,texture_coords.y));//Pixel on the left

	vec4 Rpixel = Texel(texture, vec2(texture_coords.x + tex_offset.x,texture_coords.y));//Pixel on the right

	vec4 Upixel = Texel(texture, vec2(texture_coords.x,texture_coords.y-tex_offset.y));//Pixel on the up

	vec4 Dpixel = Texel(texture, vec2(texture_coords.x,texture_coords.y+tex_offset.y));//Pixel on the down
		
	//Prevents smoke freeze at bottom
	if (pixel_coords.y > screen.y - 2) {
		pixel.a = 0;
	} else {
		pixel.a += .166666667 * (Lpixel.a +  Rpixel.a + Dpixel.a * 3 + Upixel.a - 6 * pixel.a);
	}
	pixel.rgb = vec3(1.0,1.0,1.0);

	return pixel;
}