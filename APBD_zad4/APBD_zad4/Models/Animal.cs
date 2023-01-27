namespace APBD_zad4.Models;

public class Animal
{

    private int _IDAnimal;
    private string _name;
    private string _description;
    private string _category;
    private string _area;
    

    public int IdAnimal
    {
        get => _IDAnimal;
        set => _IDAnimal = value;
    }

    public string Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Description
    {
        get => _description;
        set => _description = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Category
    {
        get => _category;
        set => _category = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Area
    {
        get => _area;
        set => _area = value ?? throw new ArgumentNullException(nameof(value));
    }
}