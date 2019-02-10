Imports System.ComponentModel
Imports System.Web

Public Class Form1

	Dim currentversion As Double = 1.31

    'UAItem v1.31 (2017.10.14)
    '버그픽스 - 아이템코드 다운로드 시 한글이 깨지던 문제 수정

    Private mousepoint As Point
    Dim v2itemcode As String = "v2itemcode.txt"
    Dim v3itemcode As String = "v3itemcode.txt"
    Dim v4itemcode As String = "v4itemcode.txt"
    Dim v2dbadress As String = "https://raw.githubusercontent.com/liArizenil/UAItem/master/" + v2itemcode
    Dim v3dbadress As String = "https://raw.githubusercontent.com/liArizenil/UAItem/master/" + v3itemcode
    Dim v4dbadress As String = "https://raw.githubusercontent.com/liArizenil/UAItem/master/" + v4itemcode
    Dim itemcodedbv2 As String = Application.StartupPath + "\DB\" + v2itemcode
    Dim itemcodedbv3 As String = Application.StartupPath + "\DB\" + v3itemcode
    Dim itemcodedbv4 As String = Application.StartupPath + "\DB\" + v4itemcode
    Dim userItemcodefile As String = Application.StartupPath + "\DB\user-itemcode.txt"
    Dim bookmarkfile As String = Application.StartupPath + "\DB\bookmarks.txt"
    Dim uivpath As String = Application.StartupPath + "\DB\uiv.txt"
    Dim icvpath As String = Application.StartupPath + "\DB\icv.txt"
    Dim itemcodedbv2list As New List(Of String)
    Dim itemcodedbv3list As New List(Of String)
    Dim itemcodedbv4list As New List(Of String)
    Dim bookmarklist As New List(Of String)
    Dim bookmarkfile_text As String
    Private Sub findItem()
        If (Version_Select.SelectedIndex = 1) Then
            dblistv2()
        ElseIf (Version_Select.SelectedIndex = 2) Then
            dblistv3()
        ElseIf (Version_Select.SelectedIndex = 3) Then
            dblistv4()
        Else
            dblistv2()
            dblistv3()
            dblistv4()
        End If
    End Sub
    Private Sub dblistv2()
        For Each db In itemcodedbv2list
            Dim Filter As String = ""
            If (Type_Filter.SelectedIndex = 0) Then
                'All
                Filter = ""
            End If
            If (Type_Filter.SelectedIndex = 1) Then
                'Item
                Filter = "Item"
            End If
            If (Type_Filter.SelectedIndex = 2) Then
                'Vehicle
                Filter = "Vehicle"
            End If

            If (db.ToString.ToUpper.Contains(idfind_txt.Text.ToUpper) And db.Split(":")(0).ToString.ToUpper.Contains(Filter.ToUpper)) Then
                Dim list = db.Split(":")
                Dim lvstr = New String() {Trim(list(0)), Trim(list(1)), Trim(list(2))}
                Dim lvitem = New ListViewItem(lvstr)
                Search_Lst.Items.Add(lvitem)
            End If
        Next
    End Sub
    Private Sub dblistv3()
        For Each db In itemcodedbv3list
            Dim Filter As String = ""
            If (Type_Filter.SelectedIndex = 0) Then
                'All
                Filter = ""
            End If
            If (Type_Filter.SelectedIndex = 1) Then
                'Item
                Filter = "Item"
            End If
            If (Type_Filter.SelectedIndex = 2) Then
                'Vehicle
                Filter = "Vehicle"
            End If
            If (Type_Filter.SelectedIndex = 3) Then
                'Job
                Filter = "Job"
            End If
            If (Type_Filter.SelectedIndex = 4) Then
                'Animal
                Filter = "Animal"
            End If
            If (db.ToString.ToUpper.Contains(idfind_txt.Text.ToUpper) And db.Split(":")(0).ToString.ToUpper.Contains(filter.ToUpper)) Then
                Dim list = db.Split(":")
                Dim lvstr = New String() {Trim(list(0)), Trim(list(1)), Trim(list(2))}
                Dim lvitem = New ListViewItem(lvstr)
                Search_Lst.Items.Add(lvitem)
            End If
        Next
    End Sub
    Private Sub dblistv4()
        For Each db In itemcodedbv4list
            Dim Filter As String = ""
            If (Type_Filter.SelectedIndex = 0) Then
                'All
                Filter = ""
            End If
            If (Type_Filter.SelectedIndex = 1) Then
                'Item
                Filter = "Item"
            End If
            If (Type_Filter.SelectedIndex = 2) Then
                'Vehicle
                Filter = "Vehicle"
            End If
            If (Type_Filter.SelectedIndex = 3) Then
                'Job
                Filter = "Job"
            End If
            If (Type_Filter.SelectedIndex = 4) Then
                'Animal
                Filter = "Animal"
            End If
            If (db.ToString.ToUpper.Contains(idfind_txt.Text.ToUpper) And db.Split(":")(0).ToString.ToUpper.Contains(filter.ToUpper)) Then
                Dim list = db.Split(":")
                Dim lvstr = New String() {Trim(list(0)), Trim(list(1)), Trim(list(2))}
                Dim lvitem = New ListViewItem(lvstr)
                Search_Lst.Items.Add(lvitem)
            End If
        Next
    End Sub


    Private Sub form1_MouseDown(ByVal sender As Object,
      ByVal e As System.Windows.Forms.MouseEventArgs) _
      Handles MyBase.MouseDown
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            '위치를 기억한다.
            mousepoint = New Point(e.X, e.Y)
        End If
    End Sub
    Private Sub form1_MouseMove(ByVal sender As Object,
      ByVal e As System.Windows.Forms.MouseEventArgs) _
      Handles MyBase.MouseMove
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            Me.Left += e.X - mousepoint.X
            Me.Top += e.Y - mousepoint.Y
            '혹은, 아래와같이 처리한다.
            'Me.Location = New Point( _
            '    Me.Location.X + e.X - mousePoint.X, _
            '    Me.Location.Y + e.Y - mousePoint.Y)
        End If
    End Sub
    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        ControlPaint.DrawBorder(e.Graphics, Me.ClientRectangle, Color.Silver, ButtonBorderStyle.Solid)
    End Sub

    Private Sub LoadItemDB()

        Dim Codelist2 As String = My.Computer.FileSystem.ReadAllText(itemcodedbv2, System.Text.Encoding.GetEncoding(949))

        '공식 아이템코드
        Dim codearr2 As Array = Codelist2.Split(vbCrLf)
        For Each codes In codearr2
            If (codes.Contains(":")) Then
                itemcodedbv2list.Add(codes.ToString)
            End If
        Next

        Dim Codelist3 As String = My.Computer.FileSystem.ReadAllText(itemcodedbv3, System.Text.Encoding.GetEncoding(949))

        Dim codearr3 As Array = Codelist3.Split(vbCrLf)
        For Each codes In codearr3
            If (codes.Contains(":")) Then
                itemcodedbv3list.Add(codes.ToString)
            End If
        Next

        Dim Codelist4 As String = My.Computer.FileSystem.ReadAllText(itemcodedbv4, System.Text.Encoding.GetEncoding(949))

        Dim codearr4 As Array = Codelist4.Split(vbCrLf)
        For Each codes In codearr4
            If (codes.Contains(":")) Then
                itemcodedbv4list.Add(codes.ToString)
            End If
        Next

        '북마크
        If My.Computer.FileSystem.FileExists(bookmarkfile) Then
            Dim Bookmarkarr As String = My.Computer.FileSystem.ReadAllText(bookmarkfile, System.Text.Encoding.GetEncoding(949))
            Dim BMlist As Array = Bookmarkarr.Split(vbCrLf)
            For Each bookmarks In BMlist
                If (bookmarks.Contains(":")) Then
                    bookmarklist.Add(bookmarks.ToString)
                End If
            Next
        End If


        '유저 아이템코드
        If My.Computer.FileSystem.FileExists(userItemcodefile) Then
            Dim Useritemcodearr As String = My.Computer.FileSystem.ReadAllText(userItemcodefile, System.Text.Encoding.GetEncoding(949))
            Dim Useritemcodelist As Array = Useritemcodearr.Split(vbCrLf)
            For Each items In Useritemcodelist
                If (items.Contains(":")) Then
                    itemcodedbv3list.Add(items.ToString)
                End If
            Next
        End If

    End Sub
    Private Sub CheckBookmark()
        If Not (My.Computer.FileSystem.FileExists(bookmarkfile)) Then
            My.Computer.FileSystem.WriteAllText(bookmarkfile, "", False)
        End If
    End Sub
    Private Sub CheckUpdate()
        On Error GoTo checkerr
        Dim Web As New Net.WebClient
        Dim IsnoFile As Boolean = False
        Dim Isupdated As Boolean = False

        My.Computer.Network.DownloadFile("https://raw.githubusercontent.com/liArizenil/UAItem/master/UA_Version", uivpath, "", "", False, 1000, True)
        Dim uaitem_version As Double = My.Computer.FileSystem.ReadAllText(uivpath)

        My.Computer.FileSystem.DeleteFile(uivpath)

        If (uaitem_version > currentversion) Then
            MsgBox("UAItem이 새 버전으로 업데이트 되었습니다." + vbCrLf + "'확인'을 누르면 다운로드 페이지로 이동합니다.", vbInformation)
            Shell("explorer https://github.com/liArizenil/UAItem/releases", vbNormalFocus)
            End
        End If

        On Error GoTo readerr

        My.Computer.Network.DownloadFile(v2dbadress, icvpath, "", "", False, 1000, True)
        Dim tempv2 As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(icvpath)
        Dim itemcode2_version As Double = tempv2.ReadLine()
        tempv2.Close()

        'V2
        If (My.Computer.FileSystem.FileExists(itemcodedbv2)) Then
            Dim fileReader As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(itemcodedbv2)
            Dim dbver As String = fileReader.ReadLine()
            fileReader.Close()

            On Error GoTo downloaderr

            If (Int(dbver) < Int(itemcode2_version)) Then
                Isupdated = True
                My.Computer.FileSystem.DeleteFile(itemcodedbv2)
                My.Computer.FileSystem.RenameFile(icvpath, v2itemcode)

                '다운로드한 파일에서 vbLf를 vbCrlf로 바꿈
                Dim ic_withlf = My.Computer.FileSystem.ReadAllText(itemcodedbv2, System.Text.Encoding.UTF8)
                Dim ic_withcrlf = ic_withlf.Replace(vbLf, vbCrLf)
                My.Computer.FileSystem.WriteAllText(itemcodedbv2, ic_withcrlf, False, encoding:=System.Text.Encoding.UTF8)
            End If
        Else
            On Error GoTo Err

            My.Computer.FileSystem.RenameFile(icvpath, v2itemcode)

            IsnoFile = True

            '다운로드한 파일에서 vbLf를 vbCrlf로 바꿈
            Dim ic_withlf = My.Computer.FileSystem.ReadAllText(itemcodedbv2, System.Text.Encoding.UTF8)
            Dim ic_withcrlf = ic_withlf.Replace(vbLf, vbCrLf)

            My.Computer.FileSystem.WriteAllText(itemcodedbv2, ic_withcrlf, False, encoding:=System.Text.Encoding.UTF8)

        End If

        My.Computer.Network.DownloadFile(v3dbadress, icvpath, "", "", False, 1000, True)
        Dim tempv3 As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(icvpath)
        Dim itemcode3_version As Double = tempv3.ReadLine()
        tempv3.Close()

        'V3
        If (My.Computer.FileSystem.FileExists(itemcodedbv3)) Then


            Dim fileReader As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(itemcodedbv3)
            Dim dbver As String
            dbver = fileReader.ReadLine()
            fileReader.Close()


            On Error GoTo downloaderr

            If (Int(dbver) < Int(itemcode3_version)) Then
                Isupdated = True
                My.Computer.FileSystem.DeleteFile(itemcodedbv3)
                My.Computer.FileSystem.RenameFile(icvpath, v3itemcode)

                '다운로드한 파일에서 vbLf를 vbCrlf로 바꿈
                Dim ic_withlf = My.Computer.FileSystem.ReadAllText(itemcodedbv3, System.Text.Encoding.UTF8)
                Dim ic_withcrlf = ic_withlf.Replace(vbLf, vbCrLf)
                My.Computer.FileSystem.WriteAllText(itemcodedbv3, ic_withcrlf, False, encoding:=System.Text.Encoding.UTF8)

            End If
        Else
            On Error GoTo Err

            My.Computer.FileSystem.RenameFile(icvpath, v3itemcode)

            IsnoFile = True

            '다운로드한 파일에서 vbLf를 vbCrlf로 바꿈
            Dim ic_withlf = My.Computer.FileSystem.ReadAllText(itemcodedbv3, System.Text.Encoding.UTF8)
            Dim ic_withcrlf = ic_withlf.Replace(vbLf, vbCrLf)

            My.Computer.FileSystem.WriteAllText(itemcodedbv3, ic_withcrlf, False, encoding:=System.Text.Encoding.UTF8)

        End If


        My.Computer.Network.DownloadFile(v4dbadress, icvpath, "", "", False, 1000, True)
        Dim tempv4 As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(icvpath)
        Dim itemcode4_version As Double = tempv4.ReadLine()
        tempv4.Close()

        'V4
        If (My.Computer.FileSystem.FileExists(itemcodedbv4)) Then
            Dim fileReader As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(itemcodedbv3)
            Dim dbver As String
            dbver = fileReader.ReadLine()
            fileReader.Close()

            On Error GoTo downloaderr

            If (Int(dbver) < Int(itemcode4_version)) Then
                Isupdated = True
                My.Computer.FileSystem.DeleteFile(itemcodedbv4)
                My.Computer.FileSystem.RenameFile(icvpath, v4itemcode)

                '다운로드한 파일에서 vbLf를 vbCrlf로 바꿈
                Dim ic_withlf = My.Computer.FileSystem.ReadAllText(itemcodedbv4, System.Text.Encoding.UTF8)
                Dim ic_withcrlf = ic_withlf.Replace(vbLf, vbCrLf)
                My.Computer.FileSystem.WriteAllText(itemcodedbv4, ic_withcrlf, False, encoding:=System.Text.Encoding.UTF8)

            End If
        Else
            On Error GoTo Err

            My.Computer.FileSystem.RenameFile(icvpath, v4itemcode)

            IsnoFile = True

            '다운로드한 파일에서 vbLf를 vbCrlf로 바꿈
            Dim ic_withlf = My.Computer.FileSystem.ReadAllText(itemcodedbv3, System.Text.Encoding.UTF8)
            Dim ic_withcrlf = ic_withlf.Replace(vbLf, vbCrLf)

            My.Computer.FileSystem.WriteAllText(itemcodedbv3, ic_withcrlf, False, encoding:=System.Text.Encoding.UTF8)



        End If
        If (IsnoFile) Then
            MsgBox("아이템코드 DB 파일이 없습니다!" + vbCrLf + "아이템코드 DB를 서버에서 다운로드합니다.", vbExclamation)
            MsgBox("아이템코드를 성공적으로 불러왔습니다.", vbInformation)
        End If
        If (Isupdated) Then
            MsgBox("아이템코드가 업데이트 되었습니다." + vbCrLf + "자동으로 새 파일을 다운로드합니다.", vbExclamation)
            MsgBox("아이템코드 업데이트에 성공했습니다!", vbInformation)
        End If
        Exit Sub
Err:
        MsgBox("서버에서 아이템코드 파일을 받던 중 오류가 발생했습니다.", vbCritical)
        End
checkerr:
        If Not (My.Computer.FileSystem.FileExists(itemcodedbv3)) Then
            MsgBox("아이템코드 파일을 읽을 수 없습니다.", vbCritical)
            End
        End If
        Exit Sub
readerr:
        MsgBox("업데이트를 위해 아이템코드 파일을 읽는 중 오류가 발생했습니다.", vbCritical)
        Exit Sub
downloaderr:
        MsgBox("업데이트 다운로드 중 오류가 발생했습니다.", vbCritical)
        Exit Sub

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Version_Select.SelectedIndex = 0
        Type_Filter.SelectedIndex = 0
        CheckUpdate()
        LoadItemDB()
        CheckBookmark()
        Me.AcceptButton = Search_Btn
        ContextMenuStrip1.Enabled = False
    End Sub
    Private Sub offbtn_Click(sender As Object, e As EventArgs) Handles offbtn.Click
        End
    End Sub
    Private Sub idfind_txt_Click(sender As Object, e As EventArgs) Handles idfind_txt.Click
        If idfind_txt.Text = "ID/이름 입력" Then
            idfind_txt.Text = ""
        End If
    End Sub
    Private Sub 해당아이템영문명칭복사ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles copy_en.Click
        Try
            Dim Eng_Name = Search_Lst.SelectedItems(0).SubItems(1).Text
            My.Computer.Clipboard.SetText(Eng_Name)
            MsgBox("영문 명칭을 클립보드에 복사했습니다!", vbInformation)
        Catch ex As Exception
            MsgBox("항목을 선택해주세요!", vbCritical)
        End Try
    End Sub
    Private Sub 해당아이템ID복사ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles copy_id.Click
        Try
            Dim ID_Name = Search_Lst.SelectedItems(0).SubItems(0).Text
            My.Computer.Clipboard.SetText(ID_Name)
            MsgBox("ID를 클립보드에 복사했습니다!", vbInformation)
        Catch ex As Exception
            MsgBox("항목을 선택해주세요!", vbCritical)
        End Try
    End Sub
    Private Sub 해당아이템한글명칭복사ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles copy_kr.Click
        Try
            Dim Kor_Name = Search_Lst.SelectedItems(0).SubItems(2).Text
            My.Computer.Clipboard.SetText(Kor_Name)
            MsgBox("한글 명칭을 클립보드에 복사했습니다!", vbInformation)
        Catch ex As Exception
            MsgBox("항목을 선택해주세요!", vbCritical)
        End Try
    End Sub

    Private Sub load_bookmark()
        Search_Lst.Items.Clear()

        For Each item In bookmarklist
            Dim codearr2 As Array = item.Split(":")
            Try
                Dim lvstr = New String() {Trim(codearr2(0)), Trim(codearr2(1)), Trim(codearr2(2))}
                Dim lvitem = New ListViewItem(lvstr)
                Search_Lst.Items.Add(lvitem)

            Catch ex As Exception
                MsgBox(codearr2(1) & "에서 오류가 발생했습니다." + vbCrLf + "일부 정보가 누락될 수 있습니다.", vbExclamation)
            End Try

        Next

        If (Search_Lst.Items.Count = 0) Then
            MsgBox("즐겨찾기된 아이템이 없습니다." + vbCrLf + "검색 결과에서 오른쪽 마우스를 눌러 추가해 보세요.", vbExclamation)
        End If

        ContextMenuStrip1.Enabled = True

    End Sub
    Private Sub Bookmark_Btn_Click(sender As Object, e As EventArgs) Handles Bookmark_Btn.Click
        load_bookmark()
    End Sub
    Private Sub Search_Btn_Click(sender As Object, e As EventArgs) Handles Search_Btn.Click
        If Not idfind_txt.Text = "ID/이름 입력" Then
            Search_Lst.Items.Clear()
            findItem()
            ContextMenuStrip1.Enabled = True

            If (Search_Lst.Items.Count = 0) Then
                MsgBox("검색 결과가 없습니다. 검색어가 정확한지 확인해 보세요.", vbExclamation)
            End If
        Else
            MsgBox("검색어를 입력하세요!", vbCritical)
        End If
    End Sub
    Private Sub 해당아이템을즐겨찾기에추가ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles add_bookmark.Click
        Try
            Dim Bookmark_Items_List = Search_Lst.SelectedItems(0).SubItems(0).Text & ":" & Search_Lst.SelectedItems(0).SubItems(1).Text & ":" & Search_Lst.SelectedItems(0).SubItems(2).Text
            bookmarklist.Add(Bookmark_Items_List)
            MsgBox("해당 항목을 즐겨찾기에 추가했습니다!", vbInformation)
            save_bookmark()

        Catch ex As Exception
            MsgBox("항목을 선택해주세요!", vbCritical)
        End Try
    End Sub
    Private Sub save_bookmark()
        bookmarkfile_text = ""
        For Each items In bookmarklist
            bookmarkfile_text = items + vbCrLf + bookmarkfile_text
        Next
        My.Computer.FileSystem.WriteAllText(bookmarkfile, bookmarkfile_text + vbCrLf, False)
    End Sub
    Private Sub remove_bookmark_Click(sender As Object, e As EventArgs) Handles remove_bookmark.Click
        Try

            Dim Bookmark_Items_List = Search_Lst.SelectedItems(0).SubItems(0).Text & ":" & Search_Lst.SelectedItems(0).SubItems(1).Text & ":" & Search_Lst.SelectedItems(0).SubItems(2).Text
            bookmarklist.Remove(Bookmark_Items_List)

            save_bookmark()

            MsgBox("해당 항목을 즐겨찾기에서 삭제했습니다.", vbInformation)

            load_bookmark()

        Catch ex As Exception
            MsgBox("항목을 선택해주세요!", vbCritical)
        End Try
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As CancelEventArgs) Handles ContextMenuStrip1.Opening
        Try
            Dim selectedItem = Search_Lst.SelectedItems(0).SubItems(0).Text & ":" & Search_Lst.SelectedItems(0).SubItems(1).Text & ":" & Search_Lst.SelectedItems(0).SubItems(2).Text
            If bookmarklist.Contains(selectedItem) Then
                remove_bookmark.Enabled = True
                add_bookmark.Enabled = False
            Else
                add_bookmark.Enabled = True
                remove_bookmark.Enabled = False
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub Version_Select_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Version_Select.SelectedIndexChanged
        Type_Filter.Items.Clear()
        Type_Filter.Items.Add("모두")
        Type_Filter.SelectedIndex = 0
        If (Version_Select.SelectedIndex = 0) Then
            'All
            Type_Filter.Items.Add("아이템")
            Type_Filter.Items.Add("차량")
            Type_Filter.Items.Add("직업")
            Type_Filter.Items.Add("동물")
        End If
        If (Version_Select.SelectedIndex = 1) Then
            '2.0
            Type_Filter.Items.Add("아이템")
            Type_Filter.Items.Add("차량")
        End If
        If (Version_Select.SelectedIndex = 2) Then
            '3.0
            Type_Filter.Items.Add("아이템")
            Type_Filter.Items.Add("차량")
            Type_Filter.Items.Add("직업")
            Type_Filter.Items.Add("동물")
        End If
        If (Version_Select.SelectedIndex = 3) Then
            Type_Filter.Items.Add("아이템")
            Type_Filter.Items.Add("차량")
            Type_Filter.Items.Add("직업")
            Type_Filter.Items.Add("동물")
        End If
    End Sub
End Class
