Imports System.Drawing
Imports Microsoft.VisualBasic
Imports System.Windows.Forms

Module Module1
    Sub Main()



















#If DEBUG Then

#End If




























        Dim query = From process In System.Diagnostics.Process.GetProcesses() _
                    Order By Process.StartTime Descending _
                    Skip 5







        Dim x As New EventArgs()


    End Sub


End Module

Public Class MyType
    Implements IEquatable(Of MyType)

#Region " IEquatable "
    Public Overloads Function Equals(ByVal other As MyType) As Boolean Implements IEquatable(Of MyType).Equals
        If other Is Nothing Then Return False
        If Object.ReferenceEquals(Me, other) Then Return True
        If Me.GetType() <> other.GetType() Then Return False
        Return Me.propertyName.Equals(other.propertyName)
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return propertyName.GetHashCode()
    End Function

    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        Return Equals(TryCast(obj, MyType))
    End Function
#End Region











    Public propertyName As String




End Class

Class ResourceClass
    Implements IDisposable

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class

''' <summary>
''' 
''' </summary>
<DebuggerDisplay("{DebuggerDisplay,nq}")> _
Public Class SomeType

End Class

















