Imports DebuggerDisplay

Public Class Form1


    Private _contactType As ContactTypes
    Public Property Contact() As ContactTypes
        Get
            Return _contactType
        End Get
        Set(ByVal value As ContactTypes)
            _contactType = value
        End Set
    End Property


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.PropertyGrid1.SelectedObject = Me
    End Sub
End Class
