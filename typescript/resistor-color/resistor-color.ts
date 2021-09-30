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

export const colorCode = (color: Color): number => {
  return (<any>Colors)[color];
}

export const COLORS = Object.keys(Colors)
                        .filter(key => typeof Colors[key as any] === 'number');
