Here is a TypeScript solution for finding the top K most frequent elements in an array:

```typescript
class MaxHeap {
    heap: [number, number][];
    constructor() {
        this.heap = [];
    }

    swap(i: number, j: number) {
        [this.heap[i], this.heap[j]] = [this.heap[j], this.heap[i]];
    }

    parent(i: number): number {
        return (i - 1) >> 1;
    }

    left(i: number): number {
        return 2 * i + 1;
    }

    right(i: number): number {
        return 2 * i + 2;
    }

    shiftUp(i: number) {
        while (i > 0 && this.heap[this.parent(i)][1] < this.heap[i][1]) {
            this.swap(i, this.parent(i));
            i = this.parent(i);
        }
    }

    shiftDown(i: number) {
        while (
            this.left(i) < this.heap.length &&
            (this.heap[i][1] < this.heap[this.left(i)][1] ||
                (this.right(i) < this.heap.length && this.heap[i][1] < this.heap[this.right(i)][1]))
        ) {
            let tmp = this.left(i);
            if (this.right(i) < this.heap.length && this.heap[tmp][1] < this.heap[this.right(i)][1]) {
                tmp = this.right(i);
            }
            this.swap(i, tmp);
            i = tmp;
        }
    }

    insert(item: [number, number]) {
        this.heap.push(item);
        this.shiftUp(this.heap.length - 1);
    }

    pop(): [number, number] | undefined {
        if (this.heap.length === 1) return this.heap.pop();
        let res = this.heap[0];
        this.heap[0] = this.heap.pop() as [number, number];
        this.shiftDown(0);
        return res;
    }
}

function topKFrequent(nums: number[], k: number): number[] {
    let map = new Map<number, number>();
    nums.forEach((num) => {
        if (map.has(num)) map.set(num, map.get(num)! + 1);
        else map.set(num, 1);
    });

    let maxHeap = new MaxHeap();
    map.forEach((value, key) => {
        maxHeap.insert([key, value]);
    });

    let res = [];
    for (let i = 0; i < k; i++) {
        let max = maxHeap.pop();
        if (max) res.push(max[0]);
    }
    return res;
}

console.log(topKFrequent([1,1,1,2,2,3], 2));
```

This solution uses a MaxHeap data structure to keep track of the frequency of each element in the array. The `topKFrequent` function first counts the frequency of each element and stores it in a Map. Then it inserts each element into the MaxHeap. Finally, it pops the top K elements from the MaxHeap and returns them.