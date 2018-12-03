const fs = require('fs');

class Part1{
    constructor(input){
        this.Input = input;
        this.Grid = {};
    }

    answer(){
        this.Input.map(x => this.calculateInchNumbers(x));
        return Object.values(this.Grid).filter(x => x > 1).length;
    }

    calculateInchNumbers(bounds){
        let startRow = Number(bounds[2]);
        let startColumn = Number(bounds[1]);
        let width = Number(bounds[3]);
        let height = Number(bounds[4]);
        for(let row = startRow; row < startRow + height; row++){
            for(let column = startColumn; column < startColumn + width; column++){
                if(this.Grid[`${row},${column}`] == undefined){
                    this.Grid[`${row},${column}`] = 0;
                }
                this.Grid[`${row},${column}`] += 1;
            }
        }
    }
}

class Part2 {
    constructor(input){
        this.Input = input;
        this.Grid = {};
        this.ViableClaims = [];
        this.FinalClaim = 0;
    }

    answer(){
        this.Input.map(x => this.calculateInchNumbers(x));
        this.ViableClaims.map(x => this.verifyClaim(x));
        return this.FinalClaim;
    }

    verifyClaim(id){
        var claim = this.Input.filter(x => x[0] === id)[0];
        console.log(claim);

        let startRow = Number(claim[2]);
        let startColumn = Number(claim[1]);
        let width = Number(claim[3]);
        let height = Number(claim[4]);
        let intersectsWithClaims = false;

        for(let row = startRow; row < startRow + height; row++){
            for(let column = startColumn; column < startColumn + width; column++){
                if(this.Grid[`${row},${column}`] > 1){
                    intersectsWithClaims = true;
                }
            }
        }
        if(!intersectsWithClaims){
            this.FinalClaim = claim[0];
            console.log(claim[0]);
        }
    }

    calculateInchNumbers(bounds){
        let startRow = Number(bounds[2]);
        let startColumn = Number(bounds[1]);
        let width = Number(bounds[3]);
        let height = Number(bounds[4]);
        let claim = bounds[0];
        let intersectsWithClaims = false;
        for(let row = startRow; row < startRow + height; row++){
            for(let column = startColumn; column < startColumn + width; column++){
                if(this.Grid[`${row},${column}`] == undefined){
                    this.Grid[`${row},${column}`] = 0;
                }
                this.Grid[`${row},${column}`] += 1;

                if(this.Grid[`${row},${column}`] > 1){
                    intersectsWithClaims = true;
                }
            }
        }
        if(!intersectsWithClaims){
            this.ViableClaims.push(claim);
        }
    }
}

class Reader{
    constructor(path){
        this._path = path;
    }

    getFormattedInput(){
        const values = fs.readFileSync(this._path)
        .toString()
        .replace(new RegExp(',', 'g'), ' ')
        .replace(new RegExp('x', 'g'), ' ')
        .replace(new RegExp(':', 'g'), '')
        .replace(new RegExp(' @', 'g'), '')
        .replace(new RegExp('\r', 'g'), '')
        .split('\n')
        .map(s => s.replace())
        .filter(s => s.length > 0)
        .map(s => s.split(' '));

        return values;
    }
}

const reader = new Reader('Day3Input.txt');
const reader2 = new Reader('Day3InputTest.txt');

// const puzzle1 = new Part1(reader.getFormattedInput());
// const puzzle1Test = new Part1(reader2.getFormattedInput()); // expected: 4

const puzzle2 = new Part2(reader.getFormattedInput());
// const puzzle2Test = new Part2(reader2.getFormattedInput()); // expected: 3


// console.log('Answer: ' + puzzle1Test.answer());
// console.log(puzzle1.answer());
// console.log('Answer: ' + puzzle2Test.answer());
console.log(puzzle2.answer());


