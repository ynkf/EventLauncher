import { Computer } from './computer.model';

export class Room {

  constructor(isEdit: boolean = false) {
    this.computer = new Computer();
    this.isEdit = isEdit;
  }

  id: number;
  roomDesignation: string;
  roomMailAddress: string;
  computerId: number;
  public computer: Computer;
  isEdit: boolean;
}
