Imports System.Net
Imports System.IO
Imports System.Text.RegularExpressions

Module Module1

    Sub Main()
        Console.WriteLine("Enter exashare embed: ")
        Dim link As String = Console.ReadLine() ' Exashare embed
        Dim Rlink As String = Extract_Exashare(link) ' MP4 link
        Console.WriteLine(Rlink)
        Console.ReadKey()
    End Sub

    Private Function Extract_Exashare(url As String)
        Dim request As WebRequest = WebRequest.Create(url)
        Using response As WebResponse = request.GetResponse()
            Using reader As New StreamReader(response.GetResponseStream())

                Dim html As String = reader.ReadToEnd()
                Dim regexL As Regex = New Regex("<iframe src=""(.*?)"" scrolling=")
                Dim rL = regexL.Match(html)
                Dim link As String = rL.Groups(1).ToString()

                Dim request2 As WebRequest = WebRequest.Create(link)
                Using response2 As WebResponse = request2.GetResponse()
                    Using reader2 As New StreamReader(response2.GetResponseStream())

                        Dim html2 As String = reader2.ReadToEnd()
                        Dim regexRL As Regex = New Regex("file:""(.*?)"",label:")
                        Dim rRL = regexRL.Match(html2)
                        Dim Rlink As String = rRL.Groups(1).ToString()
                        Return Rlink

                    End Using
                End Using

            End Using
        End Using
    End Function

End Module
