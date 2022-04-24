// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/InvertColour" {
Properties 
	{
        _MainTex ("Texture", 2D) = "white" {}
	}
	
	SubShader 
	{
		Tags { "Queue"="Transparent" }

		Pass
		{
		   ZWrite On
		   ColorMask 0
		}
        Blend OneMinusDstColor OneMinusSrcAlpha //invert blending, so long as FG color is 1,1,1,1
        BlendOp Add
        
        Pass
		{ 
		
CGPROGRAM
#pragma vertex vert
#pragma fragment frag 
            sampler2D _MainTex;
            float4 _MainTex_ST;

#include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

v2f vert( appdata i )
{
	v2f o;
	o.vertex = UnityObjectToClipPos(i.vertex);
	o.uv = i.uv;
	return o;
}

fixed4 frag( v2f i ) : COLOR
{
	fixed4 col = tex2D(_MainTex, i.uv);
	if (col.a < 0.2) discard;
  return col;
}

ENDCG
}
}
}

