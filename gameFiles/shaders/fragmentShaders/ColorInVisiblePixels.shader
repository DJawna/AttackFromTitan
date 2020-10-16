shader_type canvas_item;
//render_mode blend_mix;
uniform vec3 replacementColor = vec3(0.4,0.6,0.9);

void fragment(){
	vec4 color = texture(TEXTURE, UV);
	if(color.a > 0.0){
		COLOR = vec4(replacementColor.x,replacementColor.y, replacementColor.z, color.a);	
	}
	else{
		COLOR = vec4(0.0,0.0,0.0, 0.0);
	}
	
}