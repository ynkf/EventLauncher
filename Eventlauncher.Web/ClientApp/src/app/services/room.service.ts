import { Room } from './../models/room.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RoomService {

  constructor(private httpClient: HttpClient) { }

  getRooms(): Observable<Room[]> {
    return this.httpClient.get<Room[]>(`${this.baseApiUrl()}/list`);
  }

  createRoom(payload: Room): Observable<any> {
    return this.httpClient.post<Room>(`${this.baseApiUrl()}/create`, payload);
  }

  private baseApiUrl() {
    return 'api/room';
  }
}
