Here is a JavaScript solution using a hash map and a priority queue:

```javascript
class PriorityQueue {
    constructor(comparator = (a, b) => a > b) {
        this._heap = [null];
        this._comparator = comparator;
    }

    size() {
        return this._heap.length - 1;
    }

    isEmpty() {
        return this.size() === 0;
    }

    peek() {
        if (this.isEmpty()) return null;
        return this._heap[1];
    }

    push(value) {
        this._heap.push(value);
        this._siftUp();
    }

    pop() {
        if (this.isEmpty()) return null;
        const poppedValue = this._heap[1];
        const bottom = this.size();
        if (bottom > 1) {
            this._swap(1, bottom);
        }
        this._heap.pop();
        this._siftDown();
        return poppedValue;
    }

    _parent(idx) {
        return Math.floor(idx / 2);
    }

    _leftChild(idx) {
        return idx * 2;
    }

    _rightChild(idx) {
        return idx * 2 + 1;
    }

    _isPresent(idx) {
        return idx <= this.size();
    }

    _swap(i, j) {
        [this._heap[i], this._heap[j]] = [this._heap[j], this._heap[i]];
    }

    _siftUp() {
        let nodeIdx = this.size();
        while (nodeIdx > 1 && this._comparator(this._heap[nodeIdx], this._heap[this._parent(nodeIdx)])) {
            this._swap(nodeIdx, this._parent(nodeIdx));
            nodeIdx = this._parent(nodeIdx);
        }
    }

    _siftDown() {
        let nodeIdx = 1;
        while (
            (this._isPresent(this._leftChild(nodeIdx)) && this._comparator(this._heap[this._leftChild(nodeIdx)], this._heap[nodeIdx])) ||
            (this._isPresent(this._rightChild(nodeIdx)) && this._comparator(this._heap[this._rightChild(nodeIdx)], this._heap[nodeIdx]))
        ) {
            let maxChildIdx = this._isPresent(this._rightChild(nodeIdx)) && this._comparator(this._heap[this._rightChild(nodeIdx)], this._heap[this._leftChild(nodeIdx)]) ? this._rightChild(nodeIdx) : this._leftChild(nodeIdx);
            this._swap(nodeIdx, maxChildIdx);
            nodeIdx = maxChildIdx;
        }
    }
}

function topKFrequent(nums, k) {
    const freqMap = new Map();
    nums.forEach(n => freqMap.set(n, (freqMap.get(n) || 0) + 1));
    const pq = new PriorityQueue((a, b) => a[1] > b[1]);
    freqMap.forEach((value, key) => {
        pq.push([key, value]);
        if (pq.size() > k) {
            pq.pop();
        }
    });
    const res = [];
    while (!pq.isEmpty()) {
        res.push(pq.pop()[0]);
    }
    return res;
}

console.log(topKFrequent([1,1,1,2,2,3], 2)); // [1, 2]
console.log(topKFrequent([1], 1)); // [1]
```
This solution first counts the frequency of each element in the array using a hash map. Then it uses a priority queue to keep track of the top K frequent elements. The priority queue is implemented as a binary heap, with the element of highest frequency at the top. When the size of the priority queue exceeds K, the element of lowest frequency is removed. Finally, the top K frequent elements are returned in an array.