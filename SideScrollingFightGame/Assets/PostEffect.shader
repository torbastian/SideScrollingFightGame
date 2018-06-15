Shader "Custom/PostEffect"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_TransitionTex("Transition Texture", 2D) = "white" {}
		_CutOff("Cut Off", Range(0, 0.8)) = 0
	}
		SubShader
		{
			// No culling or depth
			Cull Off ZWrite Off ZTest Always

			Pass
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag

				#include "UnityCG.cginc"

				struct appdata
				{
					float4 vertex : POSITION;
					float2 uv : TEXCOORD0;
				};

				struct v2f
				{
					float2 uv : TEXCOORD0;
					float4 vertex : SV_POSITION;
				};

				v2f vert(appdata v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = v.uv;
					return o;
				}

				sampler2D _MainTex;
				sampler2D _TransitionTex;
				float _CutOff;

				float4 frag(v2f i) : SV_Target
				{

				float4 Col = tex2D(_MainTex, i.uv);

				fixed4 transit = tex2D(_TransitionTex, i.uv);
				if (transit.b < _CutOff)
					Col = 1 - Col;

				return Col;
			}
			ENDCG
		}
		}
}
