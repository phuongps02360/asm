Imports System.Data.SqlClient
Imports System.Data.DataTable
Public Class frm_qlsp
    Dim tb As New DataTable
    Dim connectstr As String = "workstation id=ps02360.mssql.somee.com;packet size=4096;user id=phuonghnps02360;pwd=123@hnps02360;data source=ps02360.mssql.somee.com;persist security info=False;initial catalog=ps02360"
    Public Sub LoadData()
        Dim ketnoi As New SqlConnection(connectstr)
        Dim sqlAdapter As New SqlDataAdapter("select * from SanPham", ketnoi)
        Try
            sqlAdapter.Fill(tb)

        Catch ex As Exception

        End Try
        dgv_dssp.DataSource = tb
        ketnoi.Close()

    End Sub
  

    Private Sub frm_qlsp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ketnoi As New SqlConnection(connectstr)
        Dim sqlAdapter As New SqlDataAdapter("select * from SanPham", ketnoi)
        Try
            ketnoi.Open()
            sqlAdapter.Fill(tb)

        Catch ex As Exception

        End Try
        dgv_dssp.DataSource = tb
        ketnoi.Close()
    End Sub

    

   
    Private Sub dgv_dssp_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_dssp.CellContentClick
        Dim index As Integer = dgv_dssp.CurrentCell.RowIndex
        txt_msp.Text = dgv_dssp.Item(0, index).Value
        txt_tsp.Text = dgv_dssp.Item(1, index).Value
        txt_dg.Text = dgv_dssp.Item(2, index).Value
        txt_sl.Text = dgv_dssp.Item(3, index).Value
        txt_ctsp.Text = dgv_dssp.Item(4, index).Value
        txt_mlsp.Text = dgv_dssp.Item(5, index).Value
    End Sub

    Private Sub btn_them_Click(sender As Object, e As EventArgs) Handles btn_them.Click
        Dim ketnoi As New SqlConnection(connectstr)
        ketnoi.Open()
        Dim stradd As String = "insert into  SanPham values (@masp, @tensp, @dgsp, @slsp, @ctsp, @mlsp)"
        Dim com As New SqlCommand(stradd, ketnoi)
        Try
            com.Parameters.AddWithValue("@masp", txt_msp.Text)
            com.Parameters.AddWithValue("@tensp", txt_tsp.Text)
            com.Parameters.AddWithValue("@dgsp", Convert.ToDouble(txt_dg.Text))
            com.Parameters.AddWithValue("@slsp", Convert.ToInt32(txt_sl.Text))
            com.Parameters.AddWithValue("@ctsp", txt_ctsp.Text)
            com.Parameters.AddWithValue("@mlsp", txt_mlsp.Text)
            com.ExecuteNonQuery()
            ketnoi.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        tb.Clear()
        dgv_dssp.DataSource = tb
        dgv_dssp.DataSource = Nothing
        LoadData()
    End Sub

    Private Sub btn_sua_Click(sender As Object, e As EventArgs) Handles btn_sua.Click
        Dim ketnoi As New SqlConnection(connectstr)
        ketnoi.Open()
        Dim stradd As String = "UPDATE SanPham SET Ten_SP=@tensp, DGia_SP=@dgsp, SL_SP=@slsp, CTiet_SP=@ctsp, MA_LOAI=@mlsp where  MA_SP=@masp"
        Dim com As New SqlCommand(stradd, ketnoi)
        Try
            com.Parameters.AddWithValue("@masp", txt_msp.Text)
            com.Parameters.AddWithValue("@tensp", txt_tsp.Text)
            com.Parameters.AddWithValue("@dgsp", Convert.ToDouble(txt_dg.Text))
            com.Parameters.AddWithValue("@slsp", Convert.ToInt32(txt_sl.Text))
            com.Parameters.AddWithValue("@ctsp", txt_ctsp.Text)
            com.Parameters.AddWithValue("@mlsp", txt_mlsp.Text)
            com.ExecuteNonQuery()
            ketnoi.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        tb.Clear()
        dgv_dssp.DataSource = tb
        dgv_dssp.DataSource = Nothing
        LoadData()



    End Sub

    Private Sub btn_thoat_Click(sender As Object, e As EventArgs) Handles btn_thoat.Click

        FRM_QUANLY.Show()
    End Sub

    Private Sub btn_xoa_Click(sender As Object, e As EventArgs) Handles btn_xoa.Click
        Dim ketnoi As New SqlConnection(connectstr)
        ketnoi.Open()
        Dim stradd As String = "delete from SanPham where MA_SP = @masp"
        Dim com As New SqlCommand(stradd, ketnoi)
        Try
            com.Parameters.AddWithValue("@masp", txt_msp.Text)
            com.ExecuteNonQuery()
            ketnoi.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        tb.Clear()
        dgv_dssp.DataSource = tb
        dgv_dssp.DataSource = Nothing
        LoadData()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class