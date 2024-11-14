Shader "Unlit/NewUnlitShader"
{
     Properties
    {
        _Color1 ("Color 1", Color) = (1,0,0,1)
        _Color2 ("Color 2", Color) = (0,1,0,1)
        _Speed ("Blink Speed", Float) = 2.0
        _MainTex ("Base Texture", 2D) = "white" { }
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

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
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            fixed4 _Color1;
            fixed4 _Color2;
            float _Speed;
            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Calcula el titileo entre Color1 y Color2 con base en el tiempo
                float t = abs(sin(_Time.y * _Speed));
                fixed4 colorBlink = lerp(_Color1, _Color2, t);

                // Obtiene el color de la textura original
                fixed4 baseColor = tex2D(_MainTex, i.uv);

                // Evita que el shader haga desaparecer el sprite al patrullar
                // Mantén la opacidad en 1 para evitar que el sprite se vuelva transparente
                baseColor.a = 1.0;  // Fuerza opacidad total

                // Combina la textura con el color titilante pero conservando la opacidad
                return baseColor * colorBlink;
            }
            ENDCG
        }
    }
    
}
