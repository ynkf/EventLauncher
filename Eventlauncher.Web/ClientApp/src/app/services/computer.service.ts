import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ComputerService {

  constructor(private httpClient: HttpClient) { }

  getComputers(): Observable<any> {
    return this.httpClient.get(`${this.baseApiUrl()}/list`);
  }

  private baseApiUrl(): string {
    return 'api/computer';
  }
}
