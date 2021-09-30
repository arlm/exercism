export enum Colors {
  black,
  brown,
  red,
  orange,
  yellow,
  green,
  blue,
  violet,
  grey,
  white,
}

type Color = keyof typeof Colors

export function decodedValue(colors: Color[]): number{
  const [firstColor, secondColor] = colors;
  const decimal: number = Colors[firstColor] * 10;
  const unit: number = Colors[secondColor];

  return decimal + unit;
}
