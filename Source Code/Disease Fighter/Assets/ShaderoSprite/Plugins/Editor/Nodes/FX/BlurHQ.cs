using UnityEngine;
using System.Collections;
using _ShaderoShaderEditorFramework;
using _ShaderoShaderEditorFramework.Utilities;
namespace _ShaderoShaderEditorFramework
{
[Node(false, "RGBA/FX/Blur HQ")]
public class BlurHQ : Node
{
    [HideInInspector] public const string ID = "BlurHQ";
    [HideInInspector] public override string GetID { get { return ID; } }
    [HideInInspector] public float Variable = 1;
 
    public static int count = 1;
    public static bool tag = false;
    public static string code;

    [HideInInspector] public bool parametersOK = true;

    public static void Init()
    {
        tag = false;
        count = 1;
    }
    public void Function()
    {
        code = "";
        code += "float4 BlurHQ(float2 uv, sampler2D source, float Intensity)\n";
        code += "{\n";
        code += "float step1 = 0.00390625f * Intensity * 0.5;\n";
        code += "float step2 = step1 * 2;\n";
        code += "float4 result = float4 (0, 0, 0, 0);\n";
        code += "float2 texCoord = float2(0, 0);\n";
        code += "texCoord = uv + float2(-step2, -step2); result += tex2D(source, texCoord);\n";
        code += "texCoord = uv + float2(-step1, -step2); result += 4.0 * tex2D(source, texCoord);\n";
        code += "texCoord = uv + float2(0, -step2); result += 6.0 * tex2D(source, texCoord);\n";
        code += "texCoord = uv + float2(step1, -step2); result += 4.0 * tex2D(source, texCoord);\n";
        code += "texCoord = uv + float2(step2, -step2); result += tex2D(source, texCoord);\n";
        code += "texCoord = uv + float2(-step2, -step1); result += 4.0 * tex2D(source, texCoord);\n";
        code += "texCoord = uv + float2(-step1, -step1); result += 16.0 * tex2D(source, texCoord);\n";
        code += "texCoord = uv + float2(0, -step1); result += 24.0 * tex2D(source, texCoord);\n";
        code += "texCoord = uv + float2(step1, -step1); result += 16.0 * tex2D(source, texCoord);\n";
        code += "texCoord = uv + float2(step2, -step1); result += 4.0 * tex2D(source, texCoord);\n";
        code += "texCoord = uv + float2(-step2, 0); result += 6.0 * tex2D(source, texCoord);\n";
        code += "texCoord = uv + float2(-step1, 0); result += 24.0 * tex2D(source, texCoord);\n";
        code += "texCoord = uv; result += 36.0 * tex2D(source, texCoord);\n";
        code += "texCoord = uv + float2(step1, 0); result += 24.0 * tex2D(source, texCoord);\n";
        code += "texCoord = uv + float2(step2, 0); result += 6.0 * tex2D(source, texCoord);\n";
        code += "texCoord = uv + float2(-step2, step1); result += 4.0 * tex2D(source, texCoord);\n";
        code += "texCoord = uv + float2(-step1, step1); result += 16.0 * tex2D(source, texCoord);\n";
        code += "texCoord = uv + float2(0, step1); result += 24.0 * tex2D(source, texCoord);\n";
        code += "texCoord = uv + float2(step1, step1); result += 16.0 * tex2D(source, texCoord);\n";
        code += "texCoord = uv + float2(step2, step1); result += 4.0 * tex2D(source, texCoord);\n";
        code += "texCoord = uv + float2(-step2, step2); result += tex2D(source, texCoord);\n";
        code += "texCoord = uv + float2(-step1, step2); result += 4.0 * tex2D(source, texCoord);\n";
        code += "texCoord = uv + float2(0, step2); result += 6.0 * tex2D(source, texCoord);\n";
        code += "texCoord = uv + float2(step1, step2); result += 4.0 * tex2D(source, texCoord);\n";
        code += "texCoord = uv + float2(step2, step2); result += tex2D(source, texCoord);\n";
        code += "result = result*0.00390625;\n";
        code += "return result;\n";
        code += "}\n";
    }


    public override Node Create(Vector2 pos)
    {
        Function();

        BlurHQ node = ScriptableObject.CreateInstance<BlurHQ>();

        node.name = "Blur HQ FX";
        node.rect = new Rect(pos.x, pos.y, 172, 210);

        node.CreateInput("UV", "SuperFloat2");
        node.CreateInput("Source", "SuperSource");
        node.CreateOutput("RGBA", "SuperFloat4");

        return node;
    }

    protected internal override void NodeGUI()
    {


        Texture2D preview = ResourceManager.LoadTexture("Textures/previews/nid_blur_hq.jpg");
        GUI.DrawTexture(new Rect(2, 0, 172, 46), preview);
        GUILayout.Space(50);

        GUILayout.BeginHorizontal();
        Inputs[0].DisplayLayout(new GUIContent("UV", "UV"));
        Outputs[0].DisplayLayout(new GUIContent("RGBA", "RGBA"));
        GUILayout.EndHorizontal();

        Inputs[1].DisplayLayout(new GUIContent("Source", "Source"));

        parametersOK = GUILayout.Toggle(parametersOK, "Add Parameter");

        // Paramaters
             if (NodeEditor._Shadero_Material != null)
            {
                NodeEditor._Shadero_Material.SetFloat(FinalVariable, Variable);
            }
        GUILayout.Label("Blur: (0 to 16) " + Variable.ToString("0.00"));
         Variable =HorizontalSlider(Variable, 0, 16);

        


    }
    private string FinalVariable;
    [HideInInspector]
    public int MemoCount = -1;
    public override bool FixCalculate()
    {
        MemoCount = count;
        count++;
        return true;
    }

    public override bool Calculate()
    {
        tag = true;

        SuperFloat2 s_in = Inputs[0].GetValue<SuperFloat2>();
        SuperSource s_in2 = Inputs[1].GetValue<SuperSource>();
        SuperFloat4 s_out = new SuperFloat4();


        string NodeCount = MemoCount.ToString();
        string DefaultName = "_BlurHQ_" + NodeCount;
        string DefaultNameVariable1 = "_BlurHQ_Intensity_" + NodeCount;
        string DefaultParameters1 = ", Range(1, 16)) = " + Variable.ToString();
        string uv = s_in.Result;
        string Source = "";

        FinalVariable = DefaultNameVariable1;

        // uv
        if (s_in2.Result == null)
        {
            Source = "_MainTex";
        }
        else
        {
            Source = s_in2.Result;
        }

        // source
        if (s_in.Result == null)
        {
            uv = "i.texcoord";
            if (Source == "_MainTex") uv = "i.texcoord";
            if (Source == "_GrabTexture") uv = "i.screenuv";
        }
        else
        {
            uv = s_in.Result;
        }

        s_out.StringPreviewLines = s_in.StringPreviewNew + s_in2.StringPreviewNew;
        if (parametersOK)
        {
            s_out.ValueLine = "float4 " + DefaultName + " = BlurHQ(" + uv + "," + Source + "," + DefaultNameVariable1 + ");\n";
        }
        else
        {
            s_out.ValueLine = "float4 " + DefaultName + " = BlurHQ(" + uv + "," + Source + "," + Variable.ToString() + ");\n";
        }
        s_out.StringPreviewNew = s_out.StringPreviewLines + s_out.ValueLine;
        s_out.ParametersLines += s_in.ParametersLines + s_in2.ParametersLines;

        s_out.Result = DefaultName;

        s_out.ParametersDeclarationLines += s_in.ParametersDeclarationLines + s_in2.ParametersDeclarationLines;
        if (parametersOK)
        {
            s_out.ParametersLines += DefaultNameVariable1 + "(\"" + DefaultNameVariable1 + "\"" + DefaultParameters1 + "\n";
        s_out.ParametersDeclarationLines += "float " + DefaultNameVariable1 + ";\n";
        }

        Outputs[0].SetValue<SuperFloat4>(s_out);

        count++;
        return true;
    }
}
}