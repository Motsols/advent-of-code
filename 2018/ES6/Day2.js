const fs = require('fs');

class Part1{
    constructor(input){
        this.Input = input;
        this.Twos = 0;
        this.Threes = 0;
        this.HasTwosBeenFound = false;
        this.HasThreesBeenFound = false;
    }

    answer() {
        this.Input.map(boxId => this.sumLetters(boxId.split('')));
        return this.Twos * this.Threes;
    }

    sumLetters(boxIdLetters) {
        var letterCount = {}
        boxIdLetters.map(l => letterCount[l] = 0); // must intiate with zeros or else I get NaN
        boxIdLetters.map(l => letterCount[l] += 1);

        Object.entries(letterCount).map(element => {
            this.countLetters(element[1]); // 0: dictionary key, 1: dictionary value
        });
        
        this.HasTwosBeenFound = false;
        this.HasThreesBeenFound = false;
    }

    countLetters(sum){
        if(sum === 2 && !this.HasTwosBeenFound){
            this.Twos += 1;
            this.HasTwosBeenFound = true;
        }
        if(sum === 3 && !this.HasThreesBeenFound){
            this.Threes +=1
            this.HasThreesBeenFound = true;
        }
    }
}

class Part2 {

    constructor(input){
        this.Input = input;
        this.SimilarityLevelRequired = 0;
        this.DiffPosition = 0;
        this.BoxId1 = '';
        this.BoxId2 = '';
    }

    answer() {
        this.SimilarityLevelRequired = this.Input[0].length -1;
        this.Input.map(boxId => this.Input.map(otherId => this.stringCompare(boxId, otherId)));
        return this.getStringExceptDiff();
    }

    stringCompare(boxId, otherId) {
        let sumSimilar = 0;
        let diffPosition = 0;
        for(let i = 0; i < boxId.length; i++){
            if(boxId[i] === otherId[i]){
                sumSimilar++;
            }
            else{
                diffPosition = i;
            }
        }

        if(sumSimilar === this.SimilarityLevelRequired){
            this.DiffPosition = diffPosition;
            if(this.BoxId1 === ''){
                this.BoxId1 = boxId;
            }
            else if (this.BoxId2 === ''){
                this.BoxId2 = boxId;
            }
        }
    }

    getStringExceptDiff() {
        let newId = '';
        for(let i = 0; i < this.BoxId1.length; i++){
            if(i !== this.DiffPosition){
                newId += this.BoxId1[i];
            }
        }
        return newId;
    }
}

class Reader{
    constructor(path){
        this._path = path;
    }

    content(){
        const values = fs.readFileSync(this._path)
        .toString()
        .split('\n')
        .map(s => s.replace(/\r$/, ''))
        .filter(s => s.length > 0);

        return values;
    }
}

const reader = new Reader('Day2Input.txt');

const puzzle = new Part1(reader.content()); // 6422
const puzzle2 = new Part2(reader.content()); // qcslyvphgkrmdawljuefotxbh

 //Tests:
//  const puzzle = new Part1(['abcdef','bababc','abbcde','abcccd','aabcdd','abcdee','ababab']); // expected: 12
 // const puzzle = new Part2(['abcde','fghij','klmno','pqrst','fguij','axcye','wvxyz']); // expected: fgij

console.log(puzzle.answer());
console.log(puzzle2.answer());
