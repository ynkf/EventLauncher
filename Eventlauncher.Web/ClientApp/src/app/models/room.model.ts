import { Computer } from './computer.model';

export class Room {
  id: number;
  roomDesignation: string;
  roomMailAdress: string;
  computerId: number;
  public computer: Computer;
}
