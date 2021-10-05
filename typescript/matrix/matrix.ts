export class Matrix {
  private readonly _rows: number[][];
  private readonly _columns: number[][] = [];

  constructor(matrix: string) {
    const rows = matrix.split("\n");
    this._rows = rows.map(row => row.split(" ").map(item => +item));
    
    for (let index = 0; index < this._rows[0].length; index++) {
      this._columns.push(this._rows.map(row => row[index]));
    }
  }

  get rows(): number[][] {
    return this._rows;
  }

  get columns(): number[][] {
    return this._columns;
  }
}
