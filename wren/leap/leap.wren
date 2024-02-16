class Year {
  static isLeap(n) {
    return n % 100 == 0 ? n % 400 == 0 : n % 4 == 0
  }
}
