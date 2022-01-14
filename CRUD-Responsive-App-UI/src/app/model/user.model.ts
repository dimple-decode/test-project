import { DocumentModel } from './document.model';
export class User {
  Id: string;
  FirstName: string;
  LastName: string;
  DateOfBirth: string;
  FileName: string;
  Document: DocumentModel;
  Action: Array<string>;
}
