import { Account } from './account';

export interface Teacher {
    name: string;
    contactNumber: string;
    address: string;
    zip: number;
    account: Account;
    userId: number;
}
