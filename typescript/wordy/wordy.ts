export const answer = (question: string): number => {
  if (!question.startsWith("What is") || !question.endsWith("?")) {
    throw new UnknownOperationError()
  }

  const expression = question
                        .substring(8, question.length - 1)
                        .trim()
                        .split(" ");

  var result = 0;
  let index = 0;

  while (index < expression.length) {
    let token = expression[index++];
    let op1 = +token;
    
    if (Number.isNaN(op1)) {
      op1 = result;
      index--;
    } else {
      if (expression.length == 1) {
        return op1;
      }
    }

    if (index >= expression.length) {
      throw new SyntaxError();
    }

    token = expression[index++];
    const operator: Operations = Operations[<Operation>token];

    if (!operator) {
      if (token == "?") {
        throw new SyntaxError();
      }

      throw new UnknownOperationError();
    }

    if (operator == Operations.divided  || operator == Operations.multiplied) {
    token = expression[index++];
    const by = Operations[<Operation>token];

      if (index >= expression.length) {
        throw new SyntaxError();
      }

      if (by != Operations.by) {
        throw new UnknownOperationError();
      }
    }

    token = expression[index++];
    const op2 = +token;

    if (Number.isNaN(op2)) {
      throw new SyntaxError();
    }

    switch (operator) {
      case Operations.plus:
        result = op1 + op2;
        break;

      case Operations.minus:
        result = op1 - op2;
        break;

      case Operations.multiplied:
        result = op1 * op2;
        break;

      case Operations.divided:
        result = op1 / op2;
        break;

      default:
        throw new UnknownOperationError();
    }
  }

  return result;
}

type Operation = keyof typeof Operations;

enum Operations {
  literal,
  plus,
  minus,
  multiplied,
  divided,
  by
}

class SyntaxError extends Error {
  constructor() {
    super('Syntax error');
  }
}

class UnknownOperationError extends Error {
  constructor() {
    super('Unknown operation');
  }
}