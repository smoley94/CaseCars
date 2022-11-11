using CaseCars.Codes;
using System.Text.RegularExpressions;

bool _loop = false;
bool _needMot = false;
bool _programLoop = false;

// Lov og krav implimenteres som konstanter
const int fourYearsControl = 4;
const int twoYearsControl = 2;

// Datoens beregning bliver implimenteret
DateCalculation _dateCalculation = new DateCalculation();

// Array af biler, som har en fabriksfejl
Models[] _cars = new Models[2];

_cars[0] = new Models() {
    Brand = "Fiat",
    Model = "Punto",
    Year = "01-01-2010",
    Mot = "01-01-2010",
    Error = "Udstødning"
};

_cars[1] = new Models() {
    Brand = "Alfa Romeo",
    Model = "Giulia",
    Year = "01-08-2019",
    Mot = "01-08-2019",
    Error = "Styrtøjet"
};

// Programmets loop
do {
    Console.Clear();

    Console.WriteLine("Indtast bilens mærke: ");
    string? _brand = Console.ReadLine();

    Console.WriteLine("Indtast bilens model: ");
    string? _model = Console.ReadLine();

    Console.WriteLine("Indtast bilens årgang (format: DD-MM-ÅÅÅÅ): ");
    string? _year = Console.ReadLine();

    // Her valideres datoen
    do {
        // Der bliver lavet et tjek på dato formattet, så brugeren ikke kan skrive det forkert
        if (Regex.IsMatch(_year, @"\d{2}\-{1}\d{2}\-{1}\d{4}")) {

            // Tjekker om datoen er valid
            if(!DateTime.TryParse(_year, out DateTime notUsed)) {
                Console.WriteLine("Ugyldig indtastning");
                Console.Write("Indtast bilens årgang (format: DD-MM-ÅÅÅÅ): ");
                _year = Console.ReadLine();
            } else _loop = true;
        } else {
            Console.WriteLine("Ugyldig indtastning");
            Console.Write("Indtast bilens årgang (format: DD-MM-ÅÅÅÅ): ");
            _year = Console.ReadLine();
        }
    } while (!_loop);

    _loop = false;

    Console.WriteLine("Indtast bilens synsdato (format: DD-MM-ÅÅÅÅ): ");
    string _mot = Console.ReadLine();

    // Her valideres datoen
    do {
        // Der bliver lavet et tjek på dato formattet, så brugeren ikke kan skrive det forkert
        if(Regex.IsMatch(_mot, @"\d{2}\-{1}\d{2}\-{1}\d{4}")) {

            // Tjekker om datoen er valid
            if (!DateTime.TryParse(_mot, out DateTime notUsed)) {
                Console.WriteLine("Ugyldig indtastning");
                Console.WriteLine("Indtast bilens synsdato (format: DD-MM-ÅÅÅÅ): ");
                _mot = Console.ReadLine();
            } else _loop = true;
        } else {
            Console.WriteLine("Ugyldig indtastning");
            Console.WriteLine("Indtast bilens synsdato (format: DD-MM-ÅÅÅÅ): ");
            _mot = Console.ReadLine();
        }
    } while (!_loop);

    // Her oprettes object af Cars, som bruger Models
    Models car = new Models() {
        Brand = _brand,
        Model = _model,
        Year = _year,
        Mot = _mot,
        Error = "Bilen har ingen fabriksfejl"
    };

    Console.Clear();


    // Brugeres interface

    // Der bliver tjekket på om bilen findes i Models array med en fabrikfejl
    foreach (var item in _cars) {
        if (item.Brand.ToLower() == car.Brand.ToLower() && item.Model.ToLower() == car.Model.ToLower() && _dateCalculation.StringToDateTime(item.Year) > _dateCalculation.StringToDateTime(car.Year)) {
            Console.WriteLine($"Mærke: {car.Brand}     Model: {car.Model}     Årgang: {car.Year}     Fabriksfejl: {item.Error}");
            Console.WriteLine($"Bilen skal synes med: {item.Error}");
            _needMot = true;
        }
    }

    // Findes bilen ikke med en fabriksfejl, så bliver der lavet et tjek på, om bilen skal synes
    while (!_needMot) {   
        // Er bilens alder mindre en 4 år:
        if (_dateCalculation.CarAge(car.Year) < fourYearsControl) {
            Console.WriteLine($"Mærke: {car.Brand}     Model: {car.Model}     Årgang: {car.Year}");
            Console.WriteLine("Bilen skal ikke synes");
            _needMot = true;

        // Er bilens alder over en 4 år og sidste synsdato er større end eller lig med 2 år:
        } else if (_dateCalculation.CarAge(car.Year) > fourYearsControl && _dateCalculation.DoesCarNeedMot(car.Mot) >= twoYearsControl) {
            Console.WriteLine($"Mærke: {car.Brand}     Model: {car.Model}     Årgang: {car.Year}");
            Console.WriteLine("Bilen skal synes");
            _needMot = true;

        // Er bilens alder over en 4 år og sidste synsdato er mindre end 2 år:
        } else {
            Console.WriteLine($"Mærke: {car.Brand}     Model: {car.Model}     Årgang: {car.Year}");
            Console.WriteLine("Bilen skal ikke synes");
            _needMot = true;
        }
    }

    // Brugeren har mulighed for at tjekke endnu en bil eller lukke programmet ned
    Console.Write("\nTryk på en vilkårlig tast for at tjekke en bil mere eller tryk q");
    string tmp = Console.ReadLine();
    if (tmp.ToLower() == "q") _programLoop = true;

} while (!_programLoop);


Console.WriteLine("Konsollen kan lukkes");
