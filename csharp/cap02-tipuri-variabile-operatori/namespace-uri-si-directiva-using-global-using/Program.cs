using System.Text;

// Fără using, ar trebui să scriem:
// System.Text.StringBuilder sb = new System.Text.StringBuilder();
StringBuilder sb = new StringBuilder();
sb.Append("Text construit eficient.");
Console.WriteLine(sb.ToString());
