Public Class Person
    Private _name As String
    Private _contact As ContactDetails

    Public ReadOnly Property Name() As String
        Get
            Return _name
        End Get
    End Property

    Public ReadOnly Property Contact() As ContactDetails
        Get
            Return _contact
        End Get
    End Property

    Public Sub New(ByVal name As String, ByVal email As String, ByVal tel As String)
        Me.New(name, New ContactDetails(email, tel))
    End Sub

    Public Sub New(ByVal name As String, ByVal contact As ContactDetails)
        _name = name
        _contact = contact
    End Sub
End Class

Public Class ContactDetails
    Private _email As String
    Private _telephone As String

    Public ReadOnly Property Email() As String
        Get
            Return _email
        End Get
    End Property

    Public Sub New(ByVal email As String, ByVal tel As String)
        _email = email
        _telephone = tel
    End Sub
End Class