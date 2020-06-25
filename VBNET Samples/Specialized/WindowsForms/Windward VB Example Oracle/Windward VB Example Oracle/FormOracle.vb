﻿
Imports System
Imports System.Data
Imports Net.windward.api.csharp
Imports System.IO
Imports WindwardReportsDrivers.net.windward.datasource.ado
Imports WindwardInterfaces.net.windward.api.csharp

Public Class FormOracle

    Public Sub OracleReport()
        'Initilize the engine
        report.Init()
        'open a inputfilestream for our template file
        Dim rtf As FileStream = File.OpenRead("../../../Samples/Oracle - Template.docx")
        'open an outputfilestream for our output
        Dim output As FileStream = File.Create("../../../Samples/Oracle Report.pdf")
        'Create a report process
        Dim myReport As Report
        myReport = New ReportPdf(rtf, output)
        'open a data object to connect to an oracle data source
        Dim strConn As String = "Data Source=oracle.windward.net:1521;Persist Security Info=True;User ID=HR;Password=HR;"
        Dim data As IReportDataSource = New AdoDataSourceImpl("Oracle.DataAccess.Client", strConn)

        'run the report process
        myReport.ProcessSetup()
        'the second parameter is the name of the data source
        myReport.ProcessData(data, "ORACLE")
        myReport.ProcessComplete()

        'close out of our template file and output
        output.Close()
        rtf.Close()

        'Open finished report
        Dim fullPath As String = Path.GetFullPath("../../../Samples/Oracle Report.pdf")
        System.Diagnostics.Process.Start(fullPath)

        Return
    End Sub

    'sql generate button
    Private Sub Generate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GenerateButton.Click
        GenerateButton.Enabled = False
        OracleReport()
        GenerateButton.Enabled = True
    End Sub

End Class
