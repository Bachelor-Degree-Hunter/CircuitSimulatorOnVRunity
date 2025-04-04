using UnityEngine;
using System.Collections.Generic;

public class XorGate : MonoBehaviour
{
    public List<InputConnector> inputs = new List<InputConnector>(); // รายชื่อ Input (ต้องมี 2 ตัว)
    public OutputConnector output; // Output ของ XOR Gate

    void Start()
    {
        foreach (var input in inputs)
        {
            input.AddXorGate(this);
        }

        // ตั้งชื่อ Input และ Output
        for (int i = 0; i < inputs.Count; i++)
        {
            if (inputs[i] != null)
            {
                inputs[i].gameObject.name = $"{gameObject.name}_IN{i + 1}";
            }
        }

        if (output != null)
        {
            output.gameObject.name = $"{gameObject.name}_OUT";
        }
    }


    void Update()
    {
        UpdateState(); // ตรวจสอบค่าตลอดเวลา
    }

    public void UpdateState()
    {
        if (inputs.Count != 2 || output == null) return; // XOR Gate ต้องมี 2 Input เท่านั้น

        int trueCount = 0;
        foreach (var input in inputs)
        {
            if (input.isOn)
            {
                trueCount++;
            }
        }

        output.isOn = (trueCount == 1); // ต้องมีค่า `true` เพียง 1 ตัวเท่านั้น
        output.UpdateState(); // แจ้งให้ Output ที่เชื่อมต่ออัปเดต
    }
}
