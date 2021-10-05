export class ComplexNumber {
  private readonly _real: number;
  private readonly _imaginary: number;

  constructor(real: number, imaginary: number) {
    this._real = real;
    this._imaginary = imaginary;
  }

  public get real(): number {
    return this._real;
  }

  public get imag(): number {
    return this._imaginary;
  }

  public add(other: ComplexNumber): ComplexNumber {
    return new ComplexNumber(
      this._real + other._real, 
      this._imaginary + other._imaginary
    );
  }

  public sub(other: ComplexNumber): ComplexNumber {
    return new ComplexNumber(
      this._real - other._real, 
      this._imaginary - other._imaginary
    );
  }

  public div(other: ComplexNumber): ComplexNumber {
    const divisor = other._real**2 + other._imaginary**2;
    return new ComplexNumber(
      (this._real * other._real + this._imaginary * other._imaginary) /
      divisor, 
      (this._imaginary * other._real - this._real * other._imaginary) /
      divisor
    );
  }

  public mul(other: ComplexNumber): ComplexNumber {
    return new ComplexNumber(
      this._real * other._real - this._imaginary * other._imaginary, 
      this._imaginary * other._real + this._real * other._imaginary
    );
  }

  public get abs(): number {
    return Math.sqrt(this._real**2 + this._imaginary**2);
  }

  public get conj(): ComplexNumber {
    return new ComplexNumber(this._real, 0 - this._imaginary);
  }

  public get exp(): ComplexNumber {
    return new ComplexNumber(
      Math.E**this.real * Math.cos(this._imaginary), 
      Math.E**this.real * Math.sin(this._imaginary)
    );
  }
}
