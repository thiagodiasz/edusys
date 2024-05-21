export class Estado {
    id: number;
    nome: string;
    uf: string;
    
    constructor(id: number, nome: string, uf: string) {
      this.id = id;
      this.nome = nome;
      this.uf = uf;        
    }
}
