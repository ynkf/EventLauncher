import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RoomService {

  constructor(private httpClient: HttpClient) { }

  getRooms(): Observable<any> {
    return this.httpClient.get(`${this.baseApiUrl()}/list`);
  }

  private baseApiUrl() {
    return 'api/room';
  }
}
