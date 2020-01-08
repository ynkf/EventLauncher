import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Computer } from '../models/computer.model';

@Injectable({
  providedIn: 'root'
})
export class ComputerService {

  constructor(private httpClient: HttpClient) { }

  getComputers(): Observable<Computer[]> {
    return this.httpClient.get<Computer[]>(`${this.baseApiUrl()}/list`);
  }

  createComputer(payload: Computer): Observable<Computer> {
    return this.httpClient.post<Computer>(`${this.baseApiUrl()}/create`, payload);
  }

  private baseApiUrl(): string {
    return 'api/computer';
  }
}
