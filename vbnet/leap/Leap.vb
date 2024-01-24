Public Module Leap
    Public Function IsLeapYear(ByVal year As Integer) As Boolean
        Return If (year Mod 100 = 0, year Mod 400 = 0, year Mod 4 = 0)
    End Function
End Module
