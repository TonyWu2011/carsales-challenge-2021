import { Injectable } from '@angular/core';
import { Observable, of , Subject} from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  private storageUrl = 'Storage';  // URL to web api

  constructor(private http: HttpClient) { }

  resetStorage(): Observable<object> {
    return this.http.post<object>(`${environment.apiBaseUrl}${this.storageUrl}`, null)
    .pipe(
      catchError(this.handleError<object>('resetStorage', {}))
    );
  }

  /**
  * Handle Http operation that failed.
  * Let the app continue.
  * @param operation - name of the operation that failed
  * @param result - optional value to return as the observable result
  */
   private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
