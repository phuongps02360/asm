Imports System.Data.SqlClient
Public Class dangnhap

    Private Sub btndangnhap_Click(sender As Object, e As EventArgs) Handles btndangnhap.Click
        Dim chuoiketnoi As String = "workstation id=ps02360.mssql.somee.com;packet size=4096;user id=phuonghnps02360;pwd=123@hnps02360;data source=ps02360.mssql.somee.com;persist security info=False;initial catalog=ps02360"
        Dim KetNoi As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim sqlAdapter As New SqlDataAdapter _
            ("select * from NHANVIEN where MA_NV='" & txtuser.Text & "' and Matkhau='" & txtpassword.Text & "' ", KetNoi)
        Dim tb As New DataTable
        Try
            KetNoi.Open()
            sqlAdapter.Fill(tb)
            If tb.Rows.Count > 0 Then
                MessageBox.Show("ket nối thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                FRM_QUANLY.Show()
                Me.Hide()
            Else
                MessageBox.Show("Sai Tai Khoan hoac Mat Khau", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnthoat_Click(sender As Object, e As EventArgs) Handles btnthoat.Click
        Me.Close()
    End Sub

    Private Sub dangnhap_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
