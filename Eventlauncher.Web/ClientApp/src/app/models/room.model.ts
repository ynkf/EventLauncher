import { Computer } from './computer.model';

export class Room {
  id: number;
  roomDesignation: string;
  roomMailAddress: string;
  computerId: number;
  public computer: Computer;
}
