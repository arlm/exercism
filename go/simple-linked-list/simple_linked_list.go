package linkedlist

import "fmt"

type Node struct {
	Value    int
	nextNode *Node
}

type List struct {
	firstNode *Node
}

func New(elements []int) *List {
	length := len(elements)
	result := List{}

	for i := 0; i < length; i++ {
		result.Push(elements[i])
	}

	return &result
}

func (l *List) Size() int {
	count := 0

	if l.firstNode == nil {
		return count
	}

	node := l.firstNode

	for node != nil {
		count++
		node = node.nextNode
	}

	return count
}

func (l *List) Push(element int) {
	lastNode := l.GetLastNode()

	if lastNode == nil {
		l.firstNode = &Node{
			Value: element,
		}
	} else {
		lastNode.nextNode = &Node{
			Value: element,
		}
	}
}

func (l *List) Pop() (int, error) {
	popNode := l.GetPopNode()

	if popNode == nil {
		if l.firstNode == nil {
			return -1, fmt.Errorf("cannot pop an empty list")
		}

		popNode = l.firstNode
		l.firstNode = nil

		return popNode.Value, nil
	}

	result := popNode.nextNode
	popNode.nextNode = nil

	return result.Value, nil
}

func (l *List) Array() []int {
	result := []int{}

	if l.firstNode == nil {
		return result
	}

	node := l.firstNode

	for node != nil {
		result = append(result, node.Value)
		node = node.nextNode
	}

	return result
}

func (l *List) Reverse() *List {
	result := &List{}

	if l.firstNode == nil {
		return result
	}

	var node *Node = nil
	var link *Node = nil
	navigationNode := l.firstNode

	for navigationNode != nil {
		link = &Node{
			Value:    navigationNode.Value,
			nextNode: node,
		}

		node = link
		navigationNode = navigationNode.nextNode
	}

	result.firstNode = link

	return result
}

func (l *List) GetLastNode() *Node {
	if l.firstNode == nil {
		return nil
	}

	node := l.firstNode

	for node.nextNode != nil {
		node = node.nextNode
	}

	return node
}

func (l *List) GetPopNode() *Node {
	if l.firstNode == nil {
		return nil
	}

	node := l.firstNode
	var previousNode *Node = nil

	for node.nextNode != nil {
		previousNode = node
		node = node.nextNode
	}

	return previousNode
}
