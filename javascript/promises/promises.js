//
// This is only a SKELETON file for the 'Pascals Triangle' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

export const promisify = (callbackFunction) => {
  return (parameter) => {
    return new Promise((resolve, reject) => {
      callbackFunction(parameter, (error, data) => {
        if (error) {
          reject(error);
        } else {
          resolve(data);
        }
      });
    });
  };
};

export const all = async (promises) => {
  try {
    const result = [];

    for (const promise of promises) {
      result.push(await promise);
    }

    return result;
  } catch (error) {
    throw error;
  }
};

export const allSettled = async (promises) => {
  const result = [];

  for (const promise of promises) {
    try {
      result.push(await promise);
    } catch (error) {
      result.push(error);
    }
  }

  return result;
};

export const race = (promises) => {
  return new Promise((resolve, reject) => {
    for (const promise of promises) {
      promise
        .then((result) => resolve(result))
        .catch((error) => reject(error));
    }
  });
};

export const any = (promises) => {
  return new Promise(async (resolve, reject) => {
    const errors = [];

    for (const promise of promises) {
      promise
        .then(
          result => resolve(result),
          error => errors.push(error)
        );
    }

    while (errors.length < promises.length) {
      await new Promise(resolve => setTimeout(resolve, 150));
    }

    reject(errors);
  });
};
