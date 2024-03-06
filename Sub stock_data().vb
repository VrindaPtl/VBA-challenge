Sub stock_data()

End Sub
Sub testing_data()

Dim last_row As Long
Dim i As Long
Dim j As Long
Dim total_volume As Double
Dim open_price As Double
Dim difference As Double
Dim close_price As Double
Dim percentage_diff As Double
Dim greatest_total_volume As Double
'-------------------------------------------------------------------------------------------
'looping through worksheets

For Each ws In Worksheets

Dim WorksheetName As String

last_row = ws.Cells(Rows.Count, 1).End(xlUp).Row

WorksheetName = ws.Name

ws.Cells(1, 8).Value = "<ticker>"
ws.Cells(1, 9).Value = "<total volume>"
ws.Cells(1, 10).Value = "<Yearly change>"
ws.Cells(1, 11).Value = "<% change>"
ws.Cells(4, 14).Value = "<greatest % increase>"
ws.Cells(5, 14).Value = "<greatset % decrease>"
ws.Cells(6, 14).Value = "<greatest volume>"

 '-----------------------------------------------------------------------------------------

'to get the first column of ticker symbol
'to get the yearly change and the % change column
'j is the row value of where our result will inputed

total_volume = 0
j = 1


For i = 2 To last_row

If ws.Cells(i, 1).Value <> ws.Cells(i - 1, 1).Value Then

j = j + 1

ws.Cells(j, 8).Value = ws.Cells(i, 1).Value


open_price = ws.Cells(i, 3).Value


ElseIf ws.Cells(i, 1).Value = ws.Cells(i - 1, 1).Value Then

close_price = ws.Cells(i, 6).Value

End If
difference = close_price - open_price
ws.Cells(j, 10).Value = difference
percentage_diff = (difference / open_price) * 100
ws.Cells(j, 11).Value = percentage_diff


'--------------------------------------------------------------------------------------
'to get the total volume column

If ws.Cells(i, 1).Value = ws.Cells(i - 1, 1).Value Then
total_volume = total_volume + ws.Cells(i, 7).Value
ws.Cells(j, 9) = total_volume



ElseIf ws.Cells(i, 1).Value <> ws.Cells(i - 1, 1).Value Then
total_volume = ws.Cells(i, 7).Value

End If
Next
'-----------------------------------------------------------------------------------------
'--------------------------------------------------------------------------------------------
'conditional formatting the yearly differece column

lastrow2 = ws.Cells(Rows.Count, "J").End(xlUp).Row

For i = 2 To lastrow2

If ws.Cells(i, 10).Value > 0 Then
ws.Cells(i, 10).Interior.ColorIndex = 4
Else
ws.Cells(i, 10).Interior.ColorIndex = 3
End If
Next

'finding the highest increase  and decrease in percentage percentage
ws.Cells(4, 16).Value = 0 'declaring the initial value of the highest percentage increase to 0
ws.Cells(5, 16).Value = 0 'declaring the initial value of the highest percentage decrease to 0
greatest_total_volume = 0

For i = 2 To lastrow2
If ws.Cells(i, 11).Value > 0 And ws.Cells(i, 11).Value > ws.Cells(4, 16).Value Then
ws.Cells(4, 16).Value = ws.Cells(i, 11).Value
ws.Cells(4, 15).Value = ws.Cells(i, 8).Value

End If
If ws.Cells(i, 11).Value < 0 And ws.Cells(i, 11).Value < ws.Cells(5, 16) Then
ws.Cells(5, 16).Value = ws.Cells(i, 11).Value
ws.Cells(5, 15).Value = ws.Cells(i, 8).Value
End If
If ws.Cells(i, 9).Value > greatest_total_volume Then
ws.Cells(6, 15).Value = ws.Cells(i, 8).Value
greatest_total_volume = ws.Cells(i, 9).Value
End If
ws.Cells(6, 16).Value = greatest_total_volume

Next
Next ws


End Sub


