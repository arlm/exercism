package linkedlist

import (
	"fmt"
)

type Node struct {
	Value    interface{}
	nextNode *Node
	prevNode *Node
}

type List struct {
	firstNode *Node
	lastNode  *Node
}

func NewList(elements ...interface{}) *List {
	length := len(elements)
	result := List{}

	for i := 0; i < length; i++ {
		result.Push(elements[i])
	}

	return &result
}

func (n *Node) Detach() {
	n.nextNode = nil
	n.prevNode = nil
}

func (n *Node) ReverseBackwards() {
	if n == nil {
		return
	}

	prevNode := n.prevNode
	nextNode := n.nextNode

	prevNode.ReverseBackwards()

	n.nextNode = prevNode
	n.prevNode = nextNode
}

func (n *Node) Next() *Node {
	return n.nextNode
}

func (n *Node) Prev() *Node {
	return n.prevNode
}

func (l *List) Unshift(v interface{}) {
	if l.firstNode == nil {
		l.firstNode = &Node{
			Value: v,
		}
		l.lastNode = l.firstNode
	} else {
		newNode := &Node{
			Value:    v,
			nextNode: l.firstNode,
		}

		l.firstNode.prevNode = newNode
		l.firstNode = newNode
	}
}

func (l *List) Push(v interface{}) {
	if l.lastNode == nil {
		l.firstNode = &Node{
			Value: v,
		}
		l.lastNode = l.firstNode
	} else {
		newNode := &Node{
			Value:    v,
			prevNode: l.lastNode,
		}

		l.lastNode.nextNode = newNode
		l.lastNode = newNode
	}
}

func (l *List) Shift() (interface{}, error) {
	if l.firstNode == nil {
		return nil, fmt.Errorf("cannot shift an empty list")
	}

	firstNode := l.firstNode
	nextNode := firstNode.nextNode

	if nextNode == nil {
		l.firstNode = nil
		l.lastNode = nil
	} else {
		nextNode.prevNode = nil
		l.firstNode = nextNode
	}

	firstNode.Detach()

	return firstNode.Value, nil
}

func (l *List) Pop() (interface{}, error) {
	if l.lastNode == nil {
		return nil, fmt.Errorf("cannot pop an empty list")
	}

	lastNode := l.lastNode
	prevNode := lastNode.prevNode

	if prevNode == nil {
		l.firstNode = nil
		l.lastNode = nil
	} else {
		prevNode.nextNode = nil
		l.lastNode = prevNode
	}

	lastNode.Detach()

	return lastNode.Value, nil
}

func (l *List) Reverse() {
	firstNode := l.firstNode
	lastNode := l.lastNode

	lastNode.ReverseBackwards()

	l.firstNode = lastNode
	l.lastNode = firstNode
}

func (l *List) First() *Node {
	return l.firstNode
}

func (l *List) Last() *Node {
	return l.lastNode
}
