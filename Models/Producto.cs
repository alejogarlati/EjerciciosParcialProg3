// Empieza aquí tu código de Producto y sus subclases

public abstract class Producto {
    public int Codigo { get; private set; }
    public string Nombre { get; private set; }
    public double Precio { get; private set; }
    public int Stock { get; private set; }
    public abstract string TipoProducto { get; }

    public virtual string ObtenerDescripcion() {
        return $"[{TipoProducto}]\nSKU: {Codigo}\nNombre: {Nombre}\nPrecio: {Precio:N2}\nStock: {Stock}";
    }

    public Producto (int codigo, string nombre, double precio, int stock) {
        this.Codigo = codigo;
        this.Nombre = nombre;
        this.Precio = precio;
        this.Stock = stock;
    }
}

public class ProductoElectronico : Producto {
    public int MesesGarantia { get; private set; }

    public string TipoProducto => "Producto Electrónico";

    public override string ObtenerDescripcion() {
        return base.ObtenerDescripcion() + $"\nMeses de garantia: {MesesGarantia}";
    }

    public ProductoElectronico (int codigo, string nombre, double precio, int stock, int mesesGarantia) : base (codigo, nombre, precio, stock) {
        this.MesesGarantia = mesesGarantia;
    }
}


public class ProductoAlimento : Producto {
    public DateTime FechaVencimiento { get; private set; }
    public string TipoProducto => "Producto Alimenticio";

    public bool Vencido() {return DateTime.Now > FechaVencimiento;}

    public override string ObtenerDescripcion() {
        return base.ObtenerDescripcion() + $"\nFecha de vencimiento: {FechaVencimiento} | {(Vencido()) ? "Está vencido." : "No está vencido"}";
    }

    public ProductoAlimento (int codigo, string nombre, double precio, int stock, DateTime fechaVencimiento) : base (codigo, nombre, precio, stock) {
        this.FechaVencimiento = fechaVencimiento;
    }
}


public class ProductoRopa : Producto {
    public enum TipoTalle { S, M, L, XL, XXL }
    public TipoTalle talle { get; private set; }
    public string Color { get; private set; }
    public string TipoProducto => "Producto de Indumentaria";


    public override string ObtenerDescripcion() {
        return base.ObtenerDescripcion() + $"\nTalle: {Talle} | Color: {Color}";
    }

    public ProductoRopa (int codigo, string nombre, double precio, int stock, TipoTalle talle, string color) : base (codigo, nombre, precio, stock) {
        this.Talle = talle;
        this.Color = color;
    }
}
