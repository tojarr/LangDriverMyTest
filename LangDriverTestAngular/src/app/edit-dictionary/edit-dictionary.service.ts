import {Injectable} from '@angular/core';
import { BaseHttpService } from '../core/basehttp.service';
import { urls } from '../core/urls';

@Injectable()
export class EditDictionaryService extends BaseHttpService{
    getDictionary(userId: string){
        return this.get(userId + '/' + urls.wordDomain).map(response => response.json());
       }

       AddWordToDictionary(userId: string, inputWord:string, inputTranslate:string){
        console.log('AddDictionary.service');
        const body = {wordOrigin: inputWord, translate: inputTranslate};
        return this.post(userId + '/' + urls.wordDomain , body).map(response => response.json());
      }

      DeleteWord(userId:string, wordId:string ){
          return this.delete(userId + '/' + urls.wordDomain + '/' + wordId).map(response => response.json());
      }

      EditWord(word){
        console.log('EditWord');
          return this.put(urls.wordDomain, word).map(response => response.json());
      }
}