Shader "Custom/FakeGlowScript" {
	Properties {
		 _MainTex ("Sprite Texture", 2D) = "white" {}
		// _Color ("Main Color", Color) = (1,1,1,1)
		 _Color ("Tint", Color) = (1,1,1,0)
		 _OutlineColor("Outline Color", Color) = (0,1,0,1)
		 _Outline("Outline width", Range(.002, 0.5)) = .005
		 PixelSnap ("Pixel snap", Float) = 0
		
	}
	SubShader {
		//Tags { "RenderType"="Opaque" }
		Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Opaque" "PreviewType"="Plane" "CanUseSpriteAtlas"="False" }
		 
		  //Name "FORWARD"
		
		  //Tags { "LIGHTMODE"="ForwardBase" "SHADOWSUPPORT"="true" "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" "PreviewType"="Plane" "CanUseSpriteAtlas"="true" }
		  ZWrite Off
		  Cull Off
		  //Lighting Off
		  Fog { Mode Off }
		  Blend SrcAlpha OneMinusSrcAlpha
		  
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		sampler2D _NormalsTex;
		fixed4 _Color;
		struct Input {
			float2 uv_MainTex;
			fixed4 color;
		};
		void vert(inout appdata_full v, out Input o)
		{
			#if defined(PIXELSNAP_ON) && !defined(SHADER_API_FLASH)
			v.vertex = UnityPixelSnap(v.vertex);
			#endif
			v.normal = float3(0,0,-1);
			v.tangent = float4(-1,0,0,1);
			UNITY_INITIALIZE_OUTPUT(Input, o);
			o.color = _Color * v.color;
			
		}
		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Transparent/VertexLit"
}
