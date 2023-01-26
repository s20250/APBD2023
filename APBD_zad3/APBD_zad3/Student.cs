using System.Text;

namespace APBD_zad3;

public class Student
{
    private string _name;
    private string _surname;
    private int _indexNo;
    private DateTime _birthdate;
    private string _kierunek;
    private string _tryb;
    private string _email;
    private string _imieOjca;
    private string _imieMatki;


    public Student(string name, string surname, int indexNo, DateTime birthdate, string kierunek, string tryb, string email, string imieOjca, string imieMatki)
    {
        _name = name;
        _surname = surname;
        _indexNo = indexNo;
        _birthdate = birthdate;
        _kierunek = kierunek;
        _tryb = tryb;
        _email = email;
        _imieOjca = imieOjca;
        _imieMatki = imieMatki;
    }
    
    public string Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Surname
    {
        get => _surname;
        set => _surname = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int IndexNo
    {
        get => _indexNo;
        set => _indexNo = value;
    }

    public DateTime Birthdate
    {
        get => _birthdate;
        set => _birthdate = value;
    }

    public string Kierunek
    {
        get => _kierunek;
        set => _kierunek = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Tryb
    {
        get => _tryb;
        set => _tryb = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Email
    {
        get => _email;
        set => _email = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string ImieOjca
    {
        get => _imieOjca;
        set => _imieOjca = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string ImieMatki
    {
        get => _imieMatki;
        set => _imieMatki = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    
}