import { Observable, of, catchError } from 'rxjs';

export abstract class BaseObservable {
  /**
   * Wraps an Observable with error handling logic.
   * @param observable The observable to handle.
   * @param fallbackValue The fallback value in case of an error.
   * @returns A safe observable with error handling.
   */
  protected handleObservable<T>(
    observable: Observable<T>,
    fallbackValue: T
  ): Observable<T> {
    return observable.pipe(
      catchError((error) => {
        console.error('Error occurred:', error);
        return of(fallbackValue); // Return fallback value on error
      })
    );
  }
}
