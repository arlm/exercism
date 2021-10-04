/// <reference path="./global.d.ts" />

import { NotAvailable, Untranslatable } from "./errors";

// @ts-check
//
// The lines above enable type checking for this file. Various IDEs interpret
// the @ts-check and reference directives. Together, they give you helpful
// autocompletion when implementing this exercise. You don't need to understand
// them in order to use it.
//
// In your own projects, files, and code, you can play with @ts-check as well.

export class TranslationService {
  /**
   * Creates a new service
   * @param {ExternalApi} api the original api
   */
  constructor(api) {
    this.api = api;
  }

  /**
   * Attempts to retrieve the translation for the given text.
   *
   * - Returns whichever translation can be retrieved, regardless the quality
   * - Forwards any error from the translation api
   *
   * @param {string} text
   * @returns {Promise<string>}
   */
  async free(text) {
    try {
      const translation = await this.api.fetch(text);
      return translation.translation;
    } catch (reason) {
      throw reason;
    }
  }

  /**
   * Batch translates the given texts using the free service.
   *
   * - Resolves all the translations (in the same order), if they all succeed
   * - Rejects with the first error that is encountered
   * - Rejects with a BatchIsEmpty error if no texts are given
   *
   * @param {string[]} texts
   * @returns {Promise<string[]>}
   */
  
  async batch(texts) {
    if (!texts || texts.length == 0) {
      throw new BatchIsEmpty();
    }

    const translations = [];

    for (const text of texts) {
      translations.push((await this.api.fetch(text)).translation);        
    }

    return translations;
  }

  requestAsync(text) {
    return new Promise((resolve, reject) => {
      this.api.request(text, error => error ? reject(error) : resolve());
    });
  }

  promisify(callback) {
    return (param) => new Promise((resolve, reject) => {
        const funcCallbak = (error) => {
          if (error) {
            return reject(error);
          } else {
            return resolve();
          }
        };

        callback.apply(this.api, [param, funcCallbak]);
      });
  }

  /**
   * Requests the service for some text to be translated.
   *
   * Note: the request service is flaky, and it may take up to three times for
   *       it to accept the request.
   *
   * @param {string} text
   * @returns {Promise<void>}
   */
  async request(text) {
    await this.fetchAndRequest(text);
  }

  async fetchAndRequest(text) {
    try {
      return await this.api.fetch(text);
    } catch (error) {
      if (error instanceof NotAvailable) {
        const requestPromise = this.promisify(this.api.request);
        await requestPromise(text)
          .catch(_ => requestPromise(text))
          .catch(_ => requestPromise(text));

        return null;
      }

      throw error;
    }
  }

  /**
   * Retrieves the translation for the given text
   *
   * - Rejects with an error if the quality can not be met
   * - Requests a translation if the translation is not available, then retries
   *
   * @param {string} text
   * @param {number} minimumQuality
   * @returns {Promise<string>}
   */
  async premium(text, minimumQuality) {
    const translation = await this.fetchAndRequest(text);

    if (translation == null) {
      return (await this.api.fetch(text)).translation;
    }

    if (translation.quality >= minimumQuality) {
      return translation.translation;
    }

    throw new QualityThresholdNotMet(text);
  }
}

/**
 * This error is used to indicate a translation was found, but its quality does
 * not meet a certain threshold. Do not change the name of this error.
 */
export class QualityThresholdNotMet extends Error {
  /**
   * @param {string} text
   */
  constructor(text) {
    super(
      `
The translation of ${text} does not meet the requested quality threshold.
    `.trim()
    );

    this.text = text;
  }
}

/**
 * This error is used to indicate the batch service was called without any
 * texts to translate (it was empty). Do not change the name of this error.
 */
export class BatchIsEmpty extends Error {
  constructor() {
    super(
      `
Requested a batch translation, but there are no texts in the batch.
    `.trim()
    );
  }
}
