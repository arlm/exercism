def hello(name='World'):
    if not isinstance(name, str):
        raise Exception("ValueError: name should be of type str")

    return 'Hello, {}!'.format(name)