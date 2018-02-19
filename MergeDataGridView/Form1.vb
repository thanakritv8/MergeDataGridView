Public Class Form1
    Dim Arr(4) As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DGV.Columns.Add("c1", "c1")
        DGV.Columns.Add("c2", "c2")
        DGV.Columns.Add("c3", "c3")
        DGV.Columns.Add("c4", "c4")
    End Sub

    Private Sub DGV_Paint(sender As Object, e As PaintEventArgs) Handles DGV.Paint
        For _r As Integer = 0 To DGV.Rows.Count - 1
            If Arr(_r) = 1 Then
                'Config Merge DataGrid
                Dim RowMerge As Integer = _r
                Dim rec As Rectangle = DGV.GetCellDisplayRectangle(0, RowMerge, True)    'Start Cell, *Start Row 
                Dim Width As Integer = 0
                For Each Item In DGV.Rows(RowMerge).Cells
                    Width += Item.Size.Width
                Next
                Dim rc As Rectangle = New Rectangle(rec.X, rec.Y, Width, DGV.Rows(RowMerge).Cells(0).Size.Height)
                'End Config Merge DataGrid
                e.Graphics.FillRectangle(Brushes.LightGray, rc) 'Config Background
                e.Graphics.DrawRectangle(Pens.Black, rc)    'Config Border
                'Config Font
                Dim format As StringFormat = New StringFormat
                format.LineAlignment = StringAlignment.Center
                format.Alignment = StringAlignment.Center
                e.Graphics.DrawString("TEST", Me.Font, Brushes.Green, rc, format)
                'End Font
            End If
        Next
    End Sub

    Private Sub btAdd_Click(sender As Object, e As EventArgs) Handles btAdd.Click
        DGV.Rows.Add("1", "2", "3", "4")
        DGV.Rows.Add("11", "22", "33", "44")
        DGV.Rows.Add("111", "222", "333", "444")
        DGV.Rows.Add("1111", "2222", "3333", "4444")
        For i As Integer = 0 To DGV.Rows.Count - 1
            'ReDim Arr(i)
            If i <> 0 And i < 3 Then
                Arr(i) = 1
            End If

        Next
        ReDim Arr(DGV.Rows.Count)
        'Arr(0) = 1
        'Arr(2) = 1
    End Sub
End Class
