export function hey(message: string): string {
	const trimmedMessage = message.trim();

	if (trimmedMessage.length == 0) {
		return "Fine. Be that way!";
	}

	const isAllCaps = trimmedMessage.toUpperCase() == trimmedMessage 
					&& trimmedMessage.toLowerCase() != trimmedMessage;
	const isQuestion = trimmedMessage.endsWith('?');

	if (isQuestion && isAllCaps) {
		return "Calm down, I know what I'm doing!";
	}

	if (isQuestion) {
		return "Sure.";
	}

	if (isAllCaps) {
		return "Whoa, chill out!";
	}

	return "Whatever.";
}
